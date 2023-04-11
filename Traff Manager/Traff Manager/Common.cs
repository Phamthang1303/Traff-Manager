using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traff_Manager
{
    internal class Common
    {
        public static string GetStatusDataGridView(DataGridView dgv, int row, int col)
        {
            string output = "";

            dgv.Invoke(new MethodInvoker(delegate ()
            {
                try
                {
                    output = dgv.Rows[row].Cells[col].Value.ToString();
                }
                catch { }
            }));

            return output;
        }
        public static string GetStatusDataGridView(DataGridView dgv, int row, string colName)
        {
            string output = "";

            try
            {
                dgv.Invoke(new MethodInvoker(delegate ()
                {
                    if (dgv.Rows[row].Cells[colName].Value != null)
                        output = dgv.Rows[row].Cells[colName].Value.ToString();
                }));
            }
            catch { }

            return output;
        }
        public static void SetDataGridView(DataGridView dgv, int row, int col, object status)
        {
            try
            {
                Application.DoEvents();
                dgv.Invoke(new MethodInvoker(delegate ()
                {
                    dgv.Rows[row].Cells[col].Value = status;
                }));
            }
            catch { }
        }
        public static void SetDataGridView(DataGridView dgv, int row, string colName, object status)
        {
            try
            {
                Application.DoEvents();
                dgv.Invoke(new MethodInvoker(delegate ()
                {
                    dgv.Rows[row].Cells[colName].Value = status;
                }));
            }
            catch (Exception ex) { }
        }

        public static void AddRow(DataGridView dgv, int row)
        {
            try
            {
                row++;
                Application.DoEvents();
                dgv.Invoke(new MethodInvoker(delegate ()
                {
                    if (dgv.Rows.Count < row)
                    {
                        dgv.Rows.Add();
                    }
                }));
            }
            catch { }
        }

        public static bool CheckClose(DataGridView dgv, int row, string colName)
        {
            bool result = false;
            //if (dgv.Rows[row].Cells["gvClose"])
            //{

            //}
            return true;
        }
    }
}
