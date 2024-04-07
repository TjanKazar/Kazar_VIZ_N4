namespace Kazar_VIZ_N4
{
    // TRY CONVERTING THE getHash() form bCrypt to string, the error is in byte arrays 
    public partial class Form1 : Form
    {
        //initial values
        public string fileType;
        public string raw;
        public string hash;
        // comparing just hash
        public string comp;
        public string compHash;
        public int UserFunctionKey;
        public Dictionary<int, string> hashingFuncs = new Dictionary<int, string>();
        public int sendCount = 1;
        public int cost;
        public string salt;
        public string saltedHash;
        public string user;
        public byte[] allBytes;
        // comparing the whole thing again
        public string anoterString;
        public string anoterHash;
        public string anoterSalt;


        public Form1()
        {
            salt = VIZ4.salt().ToString();
            Console.WriteLine("salt:");
            Console.WriteLine(salt);
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
                raw = File.ReadAllText(filePath);
                Console.WriteLine("rawBytes");
                foreach (char c in raw)
                    Console.Write(c);
                fileType = VIZ4.FileTypeFromPath(filePath);
                Console.WriteLine("File Type : ");
                Console.WriteLine(fileType);
                Console.WriteLine();
            }
            if (UserFunctionKey != 4)
            {
                hash = VIZ4.getHash(UserFunctionKey, raw);
                string temp = raw + salt;
                Console.WriteLine("our value of temp : ");
                Console.WriteLine("-----------original------------");
                foreach (char c in temp)
                    Console.Write(c);
                Console.WriteLine();
                Console.WriteLine("-----------original--end----------");
                Console.WriteLine();
                saltedHash = VIZ4.getHash(UserFunctionKey, temp);
            }
            else
            {
                Console.WriteLine("-----------original------------");

                hash = VIZ4.GetHashBCrypt(raw, cost);
                string temp = raw + salt;
                Console.WriteLine("cost of original : " + cost);
                Console.WriteLine(temp);
                saltedHash = VIZ4.GetHashBCrypt(temp, cost);
                Console.WriteLine("-----------original--end----------");

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

                    File.WriteAllText(filePath, hash);
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
                comp = File.ReadAllText(filePath);
                Console.WriteLine(filePath);
                fileType = VIZ4.FileTypeFromPath(filePath);
                Console.WriteLine(fileType);
            }
            compHash = VIZ4.getHash(UserFunctionKey, comp);
        }

        private void compare_Click(object sender, EventArgs e)
        {
            bool match = true;
            if (compHash.Length != hash.Length)
                MessageBox.Show("The two hashes differ. Integrity compromised.");
            else
            {
                for (int i = 0; i < hash.Length; i++)
                {
                    if (compHash[i] != hash[i])
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
                string temp;
                string filePath = openFileDialog1.FileName;
                temp = File.ReadAllText(filePath);
                Console.WriteLine(filePath);
                fileType = VIZ4.FileTypeFromPath(filePath);
                Console.WriteLine(fileType);
                hash = temp;

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
                string temp;
                string filePath = openFileDialog1.FileName;
                temp = File.ReadAllText(filePath);
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

                    File.WriteAllText(filePath, saltedHash);
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
                        writer.WriteLine("Salt:");
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
                    string temp = saltedHash;
                    string filePath = saveFileDialog1.FileName;

                    File.WriteAllText(filePath, temp);
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
            anoterString = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            anoterSalt = textBox3.Text;
            Console.WriteLine("anoterSalt");
            foreach (char b in anoterSalt)
            {
                Console.Write(b);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string temp = anoterString + anoterSalt;
            string hash = "";
            if (UserFunctionKey != 4)
            {
                Console.WriteLine("hash value :");
                Console.WriteLine();
                Console.WriteLine();
                foreach (char c in temp)
                    Console.Write(c);
                hash = VIZ4.getHash(UserFunctionKey, temp);
            }
            else
            {
                Console.WriteLine("------------temp--------------");
                hash = VIZ4.GetHashBCrypt(temp, cost);
                Console.WriteLine(temp);
                Console.WriteLine("temp");
                Console.WriteLine("cost of temp : " + cost);
                Console.WriteLine("------------temp--end--------------");

            }

            bool match = true;
            Console.WriteLine("hash: " + hashingFuncs[UserFunctionKey]);
            Console.WriteLine("-----------hash----------");
            Console.WriteLine(hash);
            Console.WriteLine("-----------hash--end--------");
            Console.WriteLine("-----------salted----------");
            Console.WriteLine(saltedHash);
            Console.WriteLine("-----------salted--end--------");
            if (UserFunctionKey != 4)
            {
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
            else
            {
                if (BCrypt.Net.BCrypt.Verify(hash, saltedHash))
                    MessageBox.Show("The two hashes match. Integrity confirmed.");
                else
                    MessageBox.Show("The two hashes differ. Integrity compromised.");
            }
        }
    }
}
