namespace Kazar_VIZ_N4
{
    public partial class Form1 : Form
    {
        public byte[] hashedBytes;
        public string fileType;
        public byte[] rawBytes;
        public int UserFunctionKey;
        public Dictionary<int, string> hashingFuncs = new Dictionary<int, string>();
        public int sendCount = 1;

        public Form1()
        {
            hashingFuncs.Add(1, "MD5");
            hashingFuncs.Add(2, "SHA-1");
            hashingFuncs.Add(3, "SHA-256");
            hashingFuncs.Add(4, "bCrypt");

            InitializeComponent();
            comboBox1.Items.Add(hashingFuncs[1]);
            comboBox1.Items.Add(hashingFuncs[2]);
            comboBox1.Items.Add(hashingFuncs[3]);
            comboBox1.Items.Add(hashingFuncs[4]);
            browse_button.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();
            UserFunctionKey = hashingFuncs.FirstOrDefault(value => value.Value == selectedValue).Key;
            browse_button.Enabled = true;
            Console.WriteLine("userFUnctionKey: " + UserFunctionKey);
        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                rawBytes = File.ReadAllBytes(filePath);
                Console.WriteLine(filePath);
                fileType = VIZ4.FileTypeFromPath(filePath);
                Console.WriteLine(fileType);
            }
            VIZ4.getHash(UserFunctionKey, rawBytes, out hashedBytes);
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.FileName = $"Hash{sendCount} {hashingFuncs[UserFunctionKey]}{fileType}";

                DialogResult userClickedOK = saveFileDialog1.ShowDialog();
                if (userClickedOK == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    File.WriteAllBytes(filePath, hashedBytes);
                    MessageBox.Show("File saved successfully.");
                    sendCount++;
                }
            }

        }
    }
}
