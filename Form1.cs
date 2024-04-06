using System.Text;

namespace Kazar_VIZ_N4
{
    public partial class Form1 : Form
    {
        //initial values
        public string fileType;
        public byte[] rawBytes;
        public byte[] hashBytes;
        // comparing just hash
        public byte[] compBytes;
        public byte[] compHash;
        public int UserFunctionKey;
        public Dictionary<int, string> hashingFuncs = new Dictionary<int, string>();
        public int sendCount = 1;
        public int cost;
        public int byteSize = 16;
        public byte[] salt;
        public byte[] saltedHash;
        public string user;
        public byte[] allBytes;
        // comparing the whole thing again for some fucing reason
        public byte[] anoterByteArray;
        public byte[] anoterHash;
        public byte[] anoterSalt;


        public Form1()
        {
            salt = VIZ4.salt(byteSize);
            Console.WriteLine("salt:");
            foreach(byte b in salt)
            {
                Console.Write(b);
            }
            hashingFuncs.Add(1, "MD5");
            hashingFuncs.Add(2, "SHA-1");
            hashingFuncs.Add(3, "SHA-256");
            hashingFuncs.Add(4, "bCrypt");


            InitializeComponent();
            for (int i = 10; i <= 20; i++)
                cost_box.Items.Add(i);
            comboBox1.Items.Add(hashingFuncs[1]);
            comboBox1.Items.Add(hashingFuncs[2]);
            comboBox1.Items.Add(hashingFuncs[3]);
            comboBox1.Items.Add(hashingFuncs[4]);
            browse_button.Enabled = false;
            cost_box.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();
            UserFunctionKey = hashingFuncs.FirstOrDefault(value => value.Value == selectedValue).Key;
            browse_button.Enabled = true;
            Console.WriteLine("userFUnctionKey: " + UserFunctionKey);
            if (selectedValue == hashingFuncs[4])
                cost_box.Enabled = true;
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
            if (UserFunctionKey != 4)
            {
            hashBytes = VIZ4.getHash(UserFunctionKey, rawBytes);
            saltedHash = hashBytes.Concat(salt).ToArray();
            saltedHash = VIZ4.getHash(UserFunctionKey ,saltedHash);
            }
            else
            {
                hashBytes = VIZ4.getHash(rawBytes, cost);
                saltedHash = hashBytes.Concat(salt).ToArray();
                saltedHash = VIZ4.getHash(saltedHash, cost);
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.FileName = $"Hash{sendCount} {hashingFuncs[UserFunctionKey]}.txt";

                DialogResult userClickedOK = saveFileDialog1.ShowDialog();
                if (userClickedOK == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    File.WriteAllBytes(filePath, hashBytes);
                    MessageBox.Show("File saved successfully.");
                    sendCount++;
                }
            }

        }

        private void cost_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cost_box.SelectedIndex != -1)
            {
                int selectedValue = (int)cost_box.SelectedItem;
                cost = selectedValue;
                Console.WriteLine(cost);
            }
        }



        private void compare_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                compBytes = File.ReadAllBytes(filePath);
                Console.WriteLine(filePath);
                fileType = VIZ4.FileTypeFromPath(filePath);
                Console.WriteLine(fileType);
            }
            compHash = VIZ4.getHash(UserFunctionKey, compBytes);
        }

        private void compare_Click(object sender, EventArgs e)
        {
            bool match = true;
            if (compHash.Length != hashBytes.Length)
                MessageBox.Show("The two hashes differ. Integrity compromised.");
            else
            {
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    if (compHash[i] != hashBytes[i])
                    {
                        match = false; break;
                    }
                }
                if (match == true)
                    MessageBox.Show("The two hashes match. Integrity confirmed.");
                else
                    MessageBox.Show("The two hashes differ. Integrity compromised.");
            }
        }

        private void override_main_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                byte[] temp;
                string filePath = openFileDialog1.FileName;
                temp = File.ReadAllBytes(filePath);
                Console.WriteLine(filePath);
                fileType = VIZ4.FileTypeFromPath(filePath);
                Console.WriteLine(fileType);
                hashBytes = temp;

            }
        }

        private void override_comp_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                byte[] temp;
                string filePath = openFileDialog1.FileName;
                temp = File.ReadAllBytes(filePath);
                Console.WriteLine(filePath);
                fileType = VIZ4.FileTypeFromPath(filePath);
                Console.WriteLine(fileType);
                compHash = temp;
            }
        }

        private void salt_hash_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.FileName = $"Hash{sendCount} {hashingFuncs[UserFunctionKey]}.txt";

                DialogResult userClickedOK = saveFileDialog1.ShowDialog();
                if (userClickedOK == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    File.WriteAllBytes(filePath, saltedHash);
                    MessageBox.Show("File saved successfully.");
                    sendCount++;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            user = textBox1.Text;
        }

        private void save_all_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.FileName = $"Hash{sendCount} {hashingFuncs[UserFunctionKey]}.txt";

                DialogResult userClickedOK = saveFileDialog1.ShowDialog();
                if (userClickedOK == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("User name:");
                        writer.WriteLine(user);
                        writer.WriteLine("Salted hash:");
                        writer.WriteLine(BitConverter.ToString(saltedHash).Replace("-", ""));
                        writer.WriteLine("Salt:");

                        Console.WriteLine("salt after something happes:");
                        string temp = "";
                        foreach (byte b in salt)
                        {
                            Console.Write(b);
                            temp += b;
                        }
                        writer.WriteLine(temp);
                    }

                    MessageBox.Show("File saved successfully.");
                    sendCount++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.FileName = $"User_Hash_Salt{sendCount} {hashingFuncs[UserFunctionKey]}.txt";

                DialogResult userClickedOK = saveFileDialog1.ShowDialog();
                if (userClickedOK == DialogResult.OK)
                {
                    byte[] temp = saltedHash;
                    string filePath = saveFileDialog1.FileName;

                    File.WriteAllBytes(filePath, temp);
                    MessageBox.Show("File saved successfully.");
                    sendCount++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            anoterByteArray = Encoding.UTF8.GetBytes(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            anoterSalt = Encoding.UTF8.GetBytes(textBox3.Text);
            Console.WriteLine("anoterSalt");
            foreach (char c in anoterSalt)
            {
                Console.Write(c);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] temp = anoterByteArray.Concat(anoterSalt).ToArray();
            byte[] hash = null;
            if (UserFunctionKey != 4)
            {
            hash = VIZ4.getHash(UserFunctionKey, temp);
            }
            else
            {
               hash = VIZ4.getHash(temp, cost);
            }
            bool match = true;
            Console.WriteLine("hash: " + hashingFuncs[UserFunctionKey]);
            foreach (char c in hash)
            { Console.Write(c);}
            Console.WriteLine("saltedHash ");
            foreach (char c in saltedHash)
            { Console.Write(c);}
            if (hash.Length != saltedHash.Length)
                MessageBox.Show("length different");
            else if (hash.Length == 0)
                MessageBox.Show("hash null");
            else
            {
                for (int i = 0; i < saltedHash.Length; i++)
                {
                    if (hash[i] != saltedHash[i])
                    {
                        match = false; break;
                    }
                }
                if (match == true)
                    MessageBox.Show("The two hashes match. Integrity confirmed.");
                else
                    MessageBox.Show("The two hashes differ. Integrity compromised.");
            }
        }
    }
}
