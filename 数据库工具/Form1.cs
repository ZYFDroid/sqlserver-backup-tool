using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace 数据库工具
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRetry_Click(sender, e);
            fileSystemWatcher.Path = ".";
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            connectDb();
            btnRefreshDB_Click(sender, e);
            btnRefreshSave_Click(sender, e);
        }

        public void connectDb() {
            tblMain.Enabled = false;
            txtStat.Text = "未连接数据库";
            if (null != conn) {
                try
                {
                    conn.Close();
                }
                catch{ }
            }

            conn = null;
            try
            {
                conn = new SqlConnection(File.ReadAllText("conStr.txt"));
                conn.Open();
                tblMain.Enabled = true;
                txtStat.Text = "已连接到 " + conn.DataSource;
            }
            catch (Exception ex) {
                conn = null;
                MessageBox.Show(ex.ToString(),"连接失败");
            }
        }

        private void btnModConn_Click(object sender, EventArgs e)
        {
            Process.Start("conStr.txt");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (null != conn)
            {
                try
                {
                    conn.Close();
                }
                catch { }
            }
        }

        public void showDbList() {
            if (conn == null) { return; }
            tblDb.Controls.Clear();
            using (SqlDataReader reader = rawQuery("SELECT name FROM SysDatabases where sid<>0x01 ORDER BY Name")) {
                while (reader.Read()) {
                    String tableName = reader.GetString(0);
                    CtlDB ctl = new CtlDB(tableName);
                    tblDb.Controls.Add(ctl);
                    ctl.OnBackupClicked += Ctl_OnBackupClicked;
                }
            }
        }

        private void Ctl_OnBackupClicked(object sender, EventArgs e)
        {
            CtlDB ctl = sender as CtlDB;
            String dbname = ctl.dbname;
            runAsync(() => {
                String backPath = Path.Combine(Environment.CurrentDirectory, dbname);
                if (!Directory.Exists(backPath)) { Directory.CreateDirectory(backPath); }
                String backName = Path.Combine(backPath, Program.toTimeStamp(DateTime.Now) + ".dbk");
                doBackup(dbname, backName);
                return "存档写入成功";
            });
            btnRefreshSave_Click(sender, e);
        }

        public SqlCommand createCommand(String sql, params string[] args) {
            String[] sqlsplit = (sql+" ").Split('?');
            sql = "";
            for (int i = 0; i < sqlsplit.Length; i++)
            {
                sql += sqlsplit[i];
                if (i < sqlsplit.Length - 1) {
                    sql += "@arg" + i;
                }
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            for (int i = 0; i < args.Length; i++)
            {
                SqlParameter par = cmd.CreateParameter();
                par.ParameterName = "arg" + i;
                par.Value = args[i];
                cmd.Parameters.Add(par);
            }
            return cmd;
        }

        public int execSql(String sql, params string[] args) {
            SqlCommand cmd = createCommand(sql, args);
            return cmd.ExecuteNonQuery();
        }

        public SqlDataReader rawQuery(String sql, params string[] args)
        {
            return createCommand(sql, args).ExecuteReader();
        }

        private void btnRefreshDB_Click(object sender, EventArgs e)
        {
            showDbList();
        }


        public void doBackup(String dbname, String path) {
            execSql("backup database ? to disk = ?", dbname, path);
        }


        public void runAsync(Func<String> act) {
            pro = new FrmProgress();
            bkgndWorker.RunWorkerAsync(act);
            pro.ShowDialog();
        }

        public FrmProgress pro = null;
        
        private void bkgndWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(333);
            Func<String> act = e.Argument as Func<String>;
            try
            {
                e.Result = act.Invoke();
            }
            catch(Exception ex) {
                e.Result = ex;
            }
        }

        private void bkgndWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MessageBox.Show(e.UserState.ToString(),"发生错误");
        }

        private void bkgndWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pro?.Close();
            pro.Dispose();
            pro = null;
            MessageBox.Show(e.Result.ToString());
        }

        private void btnRefreshSave_Click(object sender, EventArgs e)
        {
            tblSave.Controls.Clear();
            foreach (String path in Directory.EnumerateDirectories(".").OrderBy(d => d))
            {
                String fullpath = Path.GetFullPath(path);
                List<long> saves = Directory.EnumerateFiles(fullpath, "*.dbk").ToList().Select(s => long.Parse(Path.GetFileNameWithoutExtension(s))).OrderByDescending(l => l).ToList();
                if (saves.Count > 0) {
                    CtlBkup ctl = new CtlBkup(Path.GetFileName(fullpath), saves[0].fromTimeStamp());
                    ctl.OnHistoryClicked += Ctl_OnHistoryClicked;
                    ctl.OnShowClicked += Ctl_OnShowClicked;
                    ctl.OnRestoreClicked += Ctl_OnRestoreClicked;
                    tblSave.Controls.Add(ctl);
                }
            }
        }

        private void Ctl_OnRestoreClicked(object sender, EventArgs e)
        {
            String dbname = (sender as CtlBkup).dbname;
            String fullpath = Path.GetFullPath(dbname);
            List<long> saves = Directory.EnumerateFiles(fullpath, "*.dbk").ToList().Select(s => long.Parse(Path.GetFileNameWithoutExtension(s))).OrderByDescending(l => l).ToList();
            if (saves.Count > 0)
            {
                String fname = Path.Combine(fullpath, saves[0] + ".dbk");
                if (MessageBox.Show("当前正在使用的用户会断开连接。要继续读取存档吗", "是否读取存档", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                    runAsync(() =>
                    {
                        restoreDb(fname, dbname);
                        return "存档已读取";
                    });
                    btnRefreshDB_Click(sender, e);
                }
            }
        }

        private void Ctl_OnShowClicked(object sender, EventArgs e)
        {
            String dbname = (sender as CtlBkup).dbname;
            Process.Start("explorer", dbname);
        }

        private void Ctl_OnHistoryClicked(object sender, EventArgs e)
        {
            String dbname = (sender as CtlBkup).dbname;
            String fullpath = Path.GetFullPath(dbname);
            List<long> saves = Directory.EnumerateFiles(fullpath, "*.dbk").ToList().Select(s => long.Parse(Path.GetFileNameWithoutExtension(s))).OrderByDescending(l => l).ToList();
            if (saves.Count > 0)
            {
                FrmDate dt = new FrmDate();
                dt.listBox1.DataSource = new BindingSource() { DataSource = saves.ToDictionary(s => s.fromTimeStamp().toTimeStr()) };
                dt.listBox1.DisplayMember = "Key";
                dt.listBox1.ValueMember = "Value";
                if (dt.ShowDialog() == DialogResult.Yes && dt.listBox1.SelectedValue != null)
                {
                    String fname = Path.Combine(fullpath, dt.listBox1.SelectedValue + ".dbk");
                    if (MessageBox.Show("当前正在使用的用户会断开连接。要继续读取存档吗", "是否读取存档", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        runAsync(() =>
                        {
                            restoreDb(fname, dbname);
                            return "存档已读取";
                        });
                        btnRefreshDB_Click(sender, e);
                    }
                }
            }
        }


        public void restoreDb(String filepath, String name) {
            if (!File.Exists(filepath)) { throw new FileNotFoundException(filepath); }
            List<Int16> sessions = new List<short>();
            using (SqlDataReader reader = rawQuery("SELECT spid FROM sysprocesses ,sysdatabases where sysprocesses.dbid=sysdatabases.dbid and sysdatabases.sid<>0x01 and sysdatabases.Name=?", name)) {
                while (reader.Read()) {
                    sessions.Add(reader.GetInt16(0));
                }
            }
            sessions.ForEach(s => execSql("kill " + s));
            execSql("if exists (select * from sys.databases where name = ?) drop database ["+name+"]", name);
            execSql("restore database ["+name+ "] from disk = ?", filepath);
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            btnRefreshSave_Click(sender, e);
        }
    }
}
