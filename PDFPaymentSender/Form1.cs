using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

namespace PDFPaymentSender
{
    public partial class Form1 : Form
    {        
        private void Form1_Load(object sender, EventArgs e)
        {
            UsersManagementList.View = View.Details;//מציג את הנתונים בעמודות
            UsersManagementList.GridLines = true;//מציג תצוגה רשתית של קווים
            UsersManagementList.FullRowSelect = true;//שורה כחולה כאשר עומדים על תא כלשהו בטבלה
            UsersManagementList.CheckBoxes = true;
        }
        string dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PDFPaymentToMail");
        private void choosefilebtn_Click(object sender, EventArgs e)
        {            
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var file_path = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    file_path = openFileDialog.FileName;
                    FilePathBox.Text = file_path.ToString();
                    PdfLoadedDocument reader = new PdfLoadedDocument(file_path.ToString());
                    FilePagesNumberBox.Text = reader.Pages.Count.ToString();
                }
            }           
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void Filllistbtn_Click(object sender, EventArgs e)
        {
            UsersManagementList.Items.Clear();
            string textfile_path = Path.Combine(dir, "pdfread.txt");            
            if (FilePathBox.Text != string.Empty)
            {
                if (File.Exists(textfile_path))
                {
                    File.Delete(textfile_path);
                }
                PdfLoadedDocument reader = new PdfLoadedDocument(FilePathBox.Text);
                PdfLoadedPageCollection pages = reader.Pages;
                for (int i = 0; i < pages.Count ; i++)
                {                    
                    PdfPageBase page = pages[i];
                    string extractedTexts = page.ExtractText(true);
                    Char[] tempArray = extractedTexts.ToCharArray();
                    Array.Reverse(tempArray);
                    extractedTexts = new string(tempArray);
                    string strText = string.Empty;
                    extractedTexts = System.Text.Encoding.UTF8.GetString(System.Text.ASCIIEncoding.Convert(System.Text.Encoding.Default, System.Text.Encoding.UTF8, System.Text.Encoding.Default.GetBytes(extractedTexts)));
                    strText = strText + extractedTexts.Replace("  ", "-");
                    string strText_second_level = string.Empty;
                    strText = System.Text.Encoding.UTF8.GetString(System.Text.ASCIIEncoding.Convert(System.Text.Encoding.Default, System.Text.Encoding.UTF8, System.Text.Encoding.Default.GetBytes(strText)));
                    strText_second_level = strText_second_level + strText.Replace(" ", string.Empty);
                    string strText_last_level = string.Empty;
                    strText_second_level = System.Text.Encoding.UTF8.GetString(System.Text.ASCIIEncoding.Convert(System.Text.Encoding.Default, System.Text.Encoding.UTF8, System.Text.Encoding.Default.GetBytes(strText_second_level)));
                    strText_last_level = strText_last_level + strText_second_level.Replace("-", " ");
                    using (FileStream fs = File.Create(textfile_path))
                    {
                        // Add some text to file    
                        byte[] pdftotext = new UTF8Encoding(true).GetBytes(strText_last_level);
                        fs.Write(pdftotext, 0, pdftotext.Length);
                    }
                    if (File.Exists(textfile_path))
                    {
                        string[] lines = File.ReadAllLines(textfile_path);
                        var lineCount = File.ReadLines(textfile_path).Count();
                        string Corrupt_ID = lines[lineCount - 15];                                              
                        string Remove_corrupt_id_spaces = Corrupt_ID.Replace(" ", string.Empty);
                        string remove_corrupt_id_last_chrachter = Remove_corrupt_id_spaces.Remove(Remove_corrupt_id_spaces.Length - 1, 1);
                        char[] temparray_with_double_zero = remove_corrupt_id_last_chrachter.ToCharArray();
                        string ID_Remove_Double_Zero = null;
                        if (temparray_with_double_zero[0].ToString() == "0" && temparray_with_double_zero[1].ToString() == "0")
                        {
                            ID_Remove_Double_Zero = remove_corrupt_id_last_chrachter.Remove(1, remove_corrupt_id_last_chrachter.Length - 1);
                        }
                        else
                        {
                            ID_Remove_Double_Zero = remove_corrupt_id_last_chrachter;
                        }
                        char[] temparray = ID_Remove_Double_Zero.ToCharArray();
                        Array.Reverse(temparray);
                        string ID_Check_If_101_End = new string(temparray);
                        string ID = null;
                        if (ID_Check_If_101_End.Length > 9)
                        {
                            ID = ID_Check_If_101_End.Substring(0, ID_Check_If_101_End.Length - 3);
                            ID = "2" + ID;
                        }
                        else
                        {
                            ID = ID_Check_If_101_End;
                        }
                        string full_name = lines[lineCount - 5];
                        string mail_address = "";
                        string[] row = { (UsersManagementList.Items.Count + 1).ToString(), full_name, mail_address, ID };
                        var listViewItem = new ListViewItem(row);
                        UsersManagementList.Items.Add(listViewItem);
                    }                    
                }
            }
            else
            {
                MessageBox.Show("עליך לבחור קובץ כדי למלא את הטבלה", "שגיאה", MessageBoxButtons.OK);
            }
        }

        private void UsersManagementList_MouseDown(object sender, MouseEventArgs e)
        {

        }
        TextBox txtBox1 = new TextBox();
        private int subItemIndex = 0;
        private ListViewItem viewItem;

        private int? xpos = null;
        public Form1()
        {
            InitializeComponent();
            UsersManagementList.Controls.Add(txtBox1);
            txtBox1.Visible = false;
            txtBox1.KeyPress += (sender, args) =>
            {
                TextBox textBox = sender as TextBox;

                if ((int)args.KeyChar == 13)
                {
                    if (viewItem != null && IsValidEmail(txtBox1.Text) == true)
                    {
                        viewItem.SubItems[subItemIndex].Text = textBox.Text;
                    }
                    else
                    {
                        MessageBox.Show("שדה כתובת מייל ריק או שלא הוזן נכון", "שגיאה", MessageBoxButtons.OK);
                    }
                    textBox.Visible = false;
                }
                else
                {
                    textBox.Visible = true;
                }
            };
        }
        private void UsersManagementList_MouseClick(object sender, MouseEventArgs e)
        {
            xpos = MousePosition.X - UsersManagementList.PointToScreen(Point.Empty).X;
            if (e.Button == MouseButtons.Left && UsersManagementList.SelectedItems.Count > 0)
            {
                viewItem = UsersManagementList.SelectedItems[0];
                var bounds = viewItem.Bounds;
                var col3_bounds = viewItem.SubItems[2].Bounds;

                if (xpos > col3_bounds.X)
                {
                    subItemIndex = 2;
                    txtBox1.SetBounds(col3_bounds.X, bounds.Y, col3_bounds.Width, bounds.Height);
                }
                txtBox1.Text = string.Empty;
                txtBox1.Visible = true;                                
            }
        }
        static void pdftextreader(string Path, string ID, string Mail_Recipent, string Name)
        {
            string dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PDFPaymentToMail");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string path_for_the_folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\PDFPaymentToMail";
            PdfLoadedDocument reader = new PdfLoadedDocument(Path);
            PdfLoadedPageCollection loadedPages = reader.Pages;
            int pageIndex = -1;
            string text = string.Empty;
            string ID_Adding_Makaf_In_Center = ID.Insert(8, "-");
            for (int i = 1; i < loadedPages.Count; i++)
            {
                PdfPageBase loadedPage = loadedPages[i];
                text = loadedPage.ExtractText();
                if (text.Contains(ID_Adding_Makaf_In_Center))
                {
                    pageIndex = i;
                    break;
                }
            }
            if (pageIndex != -1)
            {                
                Syncfusion.Pdf.PdfDocument document = new Syncfusion.Pdf.PdfDocument();
                document.ImportPage(reader, pageIndex);
                string file_name = Name + ".pdf";
                PdfSecurity security = document.Security;
                security.KeySize = PdfEncryptionKeySize.Key256BitRevision6;
                security.Algorithm = PdfEncryptionAlgorithm.AES;
                security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;
                security.OwnerPassword = ID;
                security.UserPassword = ID;
                string path_for_saving_the_pdffile = System.IO.Path.Combine(path_for_the_folder, file_name);
                document.Save(path_for_saving_the_pdffile);
                document.Close(true);
                reader.Close(true);
                dynamic app = Activator.CreateInstance(Type.GetTypeFromProgID("Outlook.Application"));
                dynamic email = app.CreateItem(0);
                email.Subject = "תלוש שכר";
                email.Body = "תלוש שכר";
                email.To = Mail_Recipent;
                email.Save();
                email.Attachments.Add(path_for_saving_the_pdffile);
                email.send();
            }
            else
            {
                MessageBox.Show("קובץ לא נמצא", "שגיאה", MessageBoxButtons.OK);
            }
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            string send = string.Empty;
            for (int i = 0; i < UsersManagementList.Items.Count; i++)
            {
                if (UsersManagementList.Items[i].SubItems[1].Text == string.Empty)
                {
                    MessageBox.Show(UsersManagementList.Items[i].SubItems[1]+"חסר שם מלא בשורה", "שגיאה", MessageBoxButtons.OK);
                    break;
                }
                else if(UsersManagementList.Items[i].SubItems[2].Text == string.Empty)
                {
                    MessageBox.Show(UsersManagementList.Items[i].SubItems[2] + "חסרה כתובת מייל בשורה", "שגיאה", MessageBoxButtons.OK);
                    break;
                }
                else if (UsersManagementList.Items[i].SubItems[3].Text == string.Empty)
                {
                    MessageBox.Show(UsersManagementList.Items[i].SubItems[3] + "חסרה תעודת זהות בשורה", "שגיאה", MessageBoxButtons.OK);
                    break;
                }
                else
                {
                    send = "yes";
                }
            }
            if (send=="yes")
            {
                for (int i = 0; i < UsersManagementList.Items.Count; i++)
                {
                    pdftextreader(FilePathBox.Text, UsersManagementList.Items[i].SubItems[3].Text, UsersManagementList.Items[i].SubItems[2].Text, UsersManagementList.Items[i].SubItems[1].Text);
                    UsersManagementList.Items[i].SubItems[4].Text = "נשלח";
                }
            }
        }
    }
}
