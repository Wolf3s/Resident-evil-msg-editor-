using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using Microsoft.Win32;
using System.Security.Principal;
using System.Diagnostics;

namespace MSG2IO
{
    class Program
    {

        protected static int[] getConversionArray()
        {
            int[] a = new int[3715];
            a[0] = 48;//número 0

            //números
            //a[1] = 48;//0            
            a[2] = 49;//1
            a[4] = 50;//2            
            a[6] = 51;//3
            a[8] = 52;//4
            a[10] = 53;//5
            a[12] = 54;//6
            a[14] = 55;//7
            a[16] = 56;//8            
            a[18] = 57;//9

            //pontuações
            a[20] = 33;//!
            a[22] = 63;//?
            a[24] = 40;//(
            a[26] = 41;//)         
            a[28] = 32;//quebra de linha
            a[30] = 38;//&
            a[32] = 58;//:           
            a[34] = 59;//;
            a[36] = 44;//,      
            a[38] = 46;//.                    
            a[40] = 34;//"                   
            a[42] = 39;//'                    
            a[44] = 126;//~                     
            a[46] = 45;//-                      
            a[48] = 43;//+
            a[50] = 47;// /
            a[52] = 64;//@                     
            a[54] = 36;//$                  

            //LETRAS MAIÚSCULAS
            a[56] = 65;//A            
            a[58] = 66;//B
            a[60] = 67;//C
            a[62] = 68;//D            
            a[64] = 69;//E
            a[66] = 70;//F
            a[68] = 71;//G
            a[70] = 72;//H
            a[72] = 73;//I
            a[74] = 74;//J
            a[76] = 75;//K
            a[78] = 76;//L
            a[80] = 77;//M
            a[82] = 78;//N
            a[84] = 79;//O
            a[86] = 80;//P
            a[88] = 81;//Q
            a[90] = 82;//R
            a[92] = 83;//S
            a[94] = 84;//T
            a[96] = 85;//U
            a[98] = 86;//V
            a[100] = 87;//W
            a[102] = 88;//X
            a[104] = 89;//Y
            a[106] = 90;//Z                                   

            //LETRAS MINÚSCULAS
            a[108] = 97;//a
            a[110] = 98;//b
            a[112] = 99;//c
            a[114] = 100;//d
            a[116] = 101;//e
            a[118] = 102;//f
            a[120] = 103;//g
            a[122] = 104;//h
            a[124] = 105;//i
            a[126] = 106;//j
            a[128] = 107;//k
            a[130] = 108;//l
            a[132] = 109;//m
            a[134] = 110;//n
            a[136] = 111;//o
            a[138] = 112;//p
            a[140] = 113;//q
            a[142] = 114;//r
            a[144] = 115;//s
            a[146] = 116;//t
            a[148] = 117;//u
            a[150] = 118;//v
            a[152] = 119;//w            
            a[154] = 120;//x
            a[156] = 121;//y
            a[158] = 122;//z              

            a[160] = 91;//[
            a[162] = 93;//]
            a[164] = 161;//¡ espanhol idiota
            a[166] = 191;//¿ espanhol imbecil
            a[168] = 174;//®
            a[170] = 176;//°
            a[172] = 192;//À                  
            a[174] = 193;//Á          
            a[176] = 194;//Â
            //Â=194, Ä=196        
            a[178] = 196;//Ä                  
            a[180] = 199;//Ç
            a[182] = 200;//È     
            a[184] = 201;//É                      
            a[186] = 202;//Ê                    
            a[188] = 203;//Ë                  
            a[190] = 204;//Ì                     
            a[192] = 205;//Í                        
            a[194] = 206;//Î                      
            a[196] = 207;//Ï                       
            a[198] = 209;//Ñ                        
            a[200] = 210;//Ò                     
            a[202] = 211;//Ó                       
            a[204] = 212;//Ô                        
            a[206] = 214;//Ö                      
            a[208] = 218;//Ú                      
            a[210] = 219;//Û                        
            a[212] = 220;//Ü                       
            a[214] = 223;//ß                      
            a[216] = 224;//à                     
            a[218] = 225;//á                        
            a[220] = 226;//â
            a[222] = 228;//ä       
            a[224] = 231;//ç                      
            a[226] = 232;//è
            a[228] = 233;//é         
            a[230] = 234;//ê                       
            a[232] = 235;//ë                       
            a[234] = 236;//ì                         
            a[236] = 237;//í               
            a[238] = 238;//î                    
            a[240] = 239;//ï                      
            a[242] = 241;//ñ                      
            a[244] = 242;//ò                      
            a[246] = 243;//ó                       
            a[248] = 244;//ô                        
            a[250] = 246;//ö               
            a[252] = 249;//ù                       
            a[254] = 250;//ú
            //
            a[256] = 251;//û
            a[258] = 252;//ü
            //a[260] = 338;//Œ
            //a[262] = 339;//œ

            //estrelinha
            a[264] = 164;

            a[266] = 61;//=
            a[272] = 217;//Ù
            a[274] = 186;//º
            a[276] = 170;//ª
            a[278] = 37;//%
            a[280] = 124;//|
            a[282] = 95;//_
            //a[288] = 368;//?
            //a[290] = 339;//?
            //a[292] = 336;//?

            a[292] = 213;//Õ
            a[294] = 245;///õ
            //falta descobrir o ã (227)
            return a;
        }

        static int getValueCharFromCoded(int value)
        {
            int[] a = getConversionArray();
            return a[value];
        }

        static int getValueCharFromText(int value)
        {
            int[] a = getConversionArray();

            for (int n = 0; n != a.Length; n++)
            {
                if (a[n] == value)
                {
                    return n;
                }
            }
            throw new Exception("nao achou o caractere " + value);
        }


        static void extract(string fileName)
        {
            //PAKFile.mount("pasta", "gv.pak", true);
            //PAKFile.unmount("gv.pak", "pasta2");
            //string fileName = "281305318_mes_event_s.MSG2";
            string fileNameTxt = fileName + ".txt";

            Console.WriteLine("Extraindo arquivo " + System.IO.Path.GetFileName(fileName));

            BinaryReader b1 = new BinaryReader(File.Open(fileName, FileMode.Open), Encoding.Default);
            //BinaryReader b2 = new BinaryReader(File.Open(fileNameTxt, FileMode.Create),Encoding.Default);
            //header
            b1.ReadInt32();
            //fool
            b1.ReadInt32();
            //tamanho do arquivo
            int fileSize = b1.ReadInt32();
            string header = "";
            for (int n = 0; n != 51; n++)
            {
                header += b1.ReadByte() + ",";
            }
            header += b1.ReadByte();

            List<string> a = new List<string>();
            List<string> b = new List<string>();
            a.Add("valor criptografado = valor plain");
            string s = "";
            string s1;
            int v1;
            int v2;
            //escreve o identificador de arquivo como primeira linha
            s += header + Environment.NewLine;
            while (true)
            {
                //tah no fim do bagulho?
                if (b1.BaseStream.Position == fileSize)
                {
                    break;
                }
                //verifica se não é quebra de linha              
                v1 = b1.ReadInt16();
                v2 = b1.ReadInt16();
                s1 = decode(v1, v2);
                s += s1;
                //s += v1 + "," + v2 + "," + s1 + Environment.NewLine;
                //Console.WriteLine(v1+","+v2+","+s1);
                //Console.ReadKey();

            }
            b1.Close();
            File.WriteAllText(fileNameTxt, s, Encoding.Default);
            Console.WriteLine("Opa, gerou o arquivo " + System.IO.Path.GetFileName(fileNameTxt));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Aperte Enter para encerrar");
        }

        protected static string decode(int number1, int number2)
        {
            string s = "";
            switch (number2)
            {
                //Í maiúsculo com acento
                case 52:
                    s += Convert.ToChar(getValueCharFromCoded(number1));
                    break;
                //caracteres
                case 59:
                    s += Convert.ToChar(getValueCharFromCoded(number1));
                    break;
                //fim de string, substituído por nova linha
                case 1025:
                    switch (number1)
                    {
                        case 0:
                            s += Environment.NewLine;
                            break;
                    }
                    break;
                //quebra de linha trocada por |
                case 1027:
                    switch (number1)
                    {
                        case 0:
                            s += "|";
                            break;
                    }
                    break;
                //j minusculo
                case 47:
                    s += Convert.ToChar(getValueCharFromCoded(number1));
                    break;
                //I maiúsculo
                case 49:
                    s += Convert.ToChar(getValueCharFromCoded(number1));
                    break;
                //i minusculo
                case 53:
                    s += Convert.ToChar(getValueCharFromCoded(number1));
                    break;
                //J maiúsculo
                case 58:
                    s += Convert.ToChar(getValueCharFromCoded(number1));
                    break;
                //mais texto
                case 60:
                    s += Convert.ToChar(getValueCharFromCoded(number1));
                    break;
                default:
                    s += "{" + number1 + "," + number2 + "}";
                    break;
            }
            //conversão de caracteres            
            s = s.Replace('Ä', 'Ã');
            s = s.Replace('ä', 'ã');
            s = s.Replace('Ö', 'ö');
            s = s.Replace('ö', 'Õ');

            return s;
        }

        public static void main (string[] args)
        {
            //extract("281305318_mes_event_s.MSG2");
            //generateCharTable("281305318_mes_event_s.MSG2");
            //rebuild("281305318_mes_event_e.MSG2.txt");
            Console.WriteLine("Extrator/Compilador MSG2 v. 1.02");
            Console.WriteLine("========================");
            Console.WriteLine("por GameVicio =)");
            Console.WriteLine("www.gamevicio.com.br");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            if (args.Length > 0)
            {
                FileInfo fi = new FileInfo(args[0]);
                if (fi.Extension == ".txt")
                {
                    rebuild(args[0]);
                }
                if (fi.Extension == ".MSG2")
                {
                    extract(args[0]);
                }
            }
            else
            {
                Console.WriteLine("Fiote/a, arrasta o arquivo MSG2 ou txt para o executável.");
                Console.WriteLine("O txt precisa ter sido gerado por este mesmo extrator");
            }
            Console.ReadKey();
        }

        protected static int[] encodeLine(string line)
        {
            List<int> i = new List<int>();

            for (int n = 0; n != line.Length; n++)
            {
                //verificar se é um {
                int[] t = new int[4];
                if (line[n] == '{')
                {
                    //procurar o final do caractere especial
                    int e = line.IndexOf('}', n);
                    string b = line.Substring(n + 1, e - n - 1);
                    string[] c = b.Split(',');

                    MemoryStream m1 = new MemoryStream();
                    BinaryWriter w1 = new BinaryWriter(m1);
                    w1.Write(Int16.Parse("" + c[0]));
                    BinaryReader r1 = new BinaryReader(m1);
                    r1.BaseStream.Position = 0;
                    t[0] = r1.ReadByte();
                    t[1] = r1.ReadByte();
                    m1.Close();
                    m1 = new MemoryStream();
                    w1 = new BinaryWriter(m1);
                    w1.Write(Int16.Parse("" + c[1]));
                    r1 = new BinaryReader(m1);
                    r1.BaseStream.Position = 0;
                    t[2] = r1.ReadByte();
                    t[3] = r1.ReadByte();
                    //avançar no caractere
                    n = e;
                }
                else
                {
                    t = encodeChar(Convert.ToInt16(line[n]));
                }
                i.Add(t[0]);
                i.Add(t[1]);
                i.Add(t[2]);
                i.Add(t[3]);
            }
            return i.ToArray();
        }

        protected static int[] encodeChar(int number)
        {
            int[] i = new int[4];
            i[2] = 59;
            i[3] = 0;

            //conversão de caracteres
            switch (number)
            {
                //Ã para Ä
                case 195:
                    number = 196;
                    break;
                //ã para ä
                case 227:
                    number = 228;
                    break;
                //Õ para Ö
                case 213:
                    number = 214;
                    break;
                //õ para ö
                case 245:
                    number = 246;
                    break;
            }

            switch (number)
            {
                //j minúsculo
                case 106:
                    i[0] = getValueCharFromText(number);
                    i[1] = 0;
                    i[2] = 47;
                    i[3] = 0;
                    break;
                //I
                case 73:
                    i[0] = getValueCharFromText(number);
                    i[1] = 0;
                    i[2] = 49;
                    i[3] = 0;
                    break;
                //i
                case 105:
                    i[0] = getValueCharFromText(number);
                    i[1] = 0;
                    i[2] = 53;
                    i[3] = 0;
                    break;
                //J
                case 74:
                    i[0] = getValueCharFromText(number);
                    i[1] = 0;
                    i[2] = 58;
                    i[3] = 0;
                    break;
                //|
                case 124:
                    i[0] = 0;
                    i[1] = 0;
                    i[2] = 3;
                    i[3] = 4;
                    break;
                default:
                    i[0] = getValueCharFromText(number);
                    i[1] = 0;
                    if (i[0] > 254)
                    {
                        MemoryStream m1 = new MemoryStream();
                        BinaryWriter w1 = new BinaryWriter(m1);
                        w1.Write(Int16.Parse("" + i[0]));
                        BinaryReader r1 = new BinaryReader(m1);
                        r1.BaseStream.Position = 0;
                        i[0] = r1.ReadByte();
                        i[1] = r1.ReadByte();
                    }
                    break;
            }
            return i;
        }

        static void rebuild(string fileNameTxt)
        {
            Console.WriteLine("Recompilando arquivo " + System.IO.Path.GetFileName(fileNameTxt));
            string fileOriginal = fileNameTxt.Replace(".txt", "");

            if (fileOriginal == fileNameTxt)
            {
                Console.WriteLine("O arquivo de texto é inválido, deve ter a extensão txt");
                return;
            }

            string newFileOriginal = fileOriginal + ".gv";

            string[] lines = File.ReadAllLines(fileNameTxt, Encoding.Default);

            BinaryWriter w1 = new BinaryWriter(File.Create(newFileOriginal), Encoding.Default);
            //cabeçalho            
            w1.Write(Convert.ToByte(77));
            w1.Write(Convert.ToByte(83));
            w1.Write(Convert.ToByte(71));
            w1.Write(Convert.ToByte(50));

            //fool
            w1.Write(Int32.Parse("64"));
            //tamanho do arquivo que por enqto não sabemos           
            w1.Write(Int32.Parse("32"));
            //importar o cabeçalho
            string[] a = lines[0].Split(',');
            for (int n = 0; n != a.Length; n++)
            {
                w1.Write(Convert.ToByte(int.Parse(a[n])));
            }


            //leitura de linhas
            for (int n = 1; n != lines.Length; n++)
            {
                string line = lines[n];
                int[] lineEncoded = encodeLine(line);
                //importar o cabeçalho
                //a = lineEncoded[0].Split(',');
                for (int y = 0; y != lineEncoded.Length; y++)
                {
                    w1.Write(Convert.ToByte(lineEncoded[y]));
                }
                //divisor de strings
                w1.Write(Convert.ToByte(0));
                w1.Write(Convert.ToByte(0));
                w1.Write(Convert.ToByte(1));
                w1.Write(Convert.ToByte(4));
            }
            w1.Close();
            //atualizar novo tamanho
            FileInfo fi = new FileInfo(newFileOriginal);
            int len = (int)fi.Length;
            w1 = new BinaryWriter(File.Open(newFileOriginal, FileMode.Open));
            w1.Seek(8, SeekOrigin.Begin);
            w1.Write(Int32.Parse("" + len));
            w1.Close();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Opa, gerou o arquivo " + System.IO.Path.GetFileName(newFileOriginal));
        }
    }
}




namespace EpicWolf
{
    public class PAKFile
    {
        //mount
        protected string m_szSourceDir = "";
        protected string m_szDestFile = "";
        //unmount
        protected string m_szSourceFile = "";
        protected string m_szDestDir = "";
        //
        protected string m_szFileHeader = "GVPAK";
        protected List<string> m_lFiles = new List<string>();
        protected List<Int32> m_lFileSizes = new List<Int32>();

        private PAKFile()
        {

        }

        public static bool mount(string sourceDirectory, string destinationFile)
        {
            PAKFile pak = new PAKFile();
            pak.sourceDirectory = sourceDirectory;
            pak.destinationFile = destinationFile;
            return pak.create();
        }

        public static bool mount(string sourceDirectory, string destinationFile, bool gzip)
        {
            PAKFile pak = new PAKFile();
            pak.sourceDirectory = sourceDirectory;
            pak.destinationFile = destinationFile;
            bool r = pak.create();
            if (r && gzip)
            {
                pak.compress();
            }
            return r;
        }


        public static bool unmount(string sourceFile, string destinationDirectory)
        {
            PAKFile pak = new PAKFile();
            pak.sourceFile = sourceFile;
            pak.destinationDirectory = destinationDirectory;
            //checar header para detectar se é um arquivo compactado
            BinaryReader fileReader = new BinaryReader(File.OpenRead(pak.sourceFile));
            //check for our file header
            string header = fileReader.ReadString();
            fileReader.Close();
            if (header != pak.fileHeader)
            {
                if (header != pak.fileHeader + "Z")
                {
                    return false;
                }
                //gziped
                pak.sourceFile = pak.decompress();
            }

            return pak.extract();
        }

        protected string sourceDirectory
        {
            get
            {
                return m_szSourceDir;
            }
            set
            {
                m_szSourceDir = value;
            }
        }

        protected string destinationFile
        {
            get
            {
                return m_szDestFile;
            }
            set
            {
                m_szDestFile = value;
            }
        }

        protected string sourceFile
        {
            get
            {
                return m_szSourceFile;
            }
            set
            {
                m_szSourceFile = value;
            }
        }

        protected string destinationDirectory
        {
            get
            {
                return m_szDestDir;
            }
            set
            {
                m_szDestDir = value;
            }
        }

        protected string fileHeader
        {
            get
            {
                return m_szFileHeader;
            }
            set
            {
                m_szFileHeader = value;
            }
        }

        protected bool create()
        {
            if (m_szDestFile == "" || m_szSourceDir == "")
            {
                return false;
            }
            DirectoryInfo dInfo = new DirectoryInfo(m_szSourceDir);
            m_szSourceDir = dInfo.FullName;
            if (!dInfo.Exists)
            {
                return false;
            }
            RecursivePAK();
            if (m_lFiles.Count == 0)
            {
                return false;
            }
            //try opening the file for writing
            try
            {
                BinaryWriter outFile = new BinaryWriter(File.Create(m_szDestFile));
                //write our file header
                outFile.Write(m_szFileHeader);
                outFile.Write((Int32)m_lFiles.Count);
                for (int ia = 0; ia < m_lFiles.Count; ia++)
                {
                    outFile.Write(m_lFiles[ia]);
                    outFile.Write(m_lFileSizes[ia]);
                }
                //set up our filestream, buffer and bytes read variables
                FileStream fRead;
                byte[] buffer = new byte[1024];
                int nRead;
                foreach (string szLocation in m_lFiles)
                {
                    nRead = 0;
                    //open our file to read from
                    fRead = File.OpenRead(m_szSourceDir + "/" + szLocation);
                    //while the number of bytes read is equal to 1024 (not the EOF) copy data to our PAK file
                    do
                    {
                        nRead = fRead.Read(buffer, 0, 1024);
                        outFile.Write(buffer, 0, nRead);
                    } while (nRead == 1024);
                    fRead.Close();
                }
                //close our PAK file
                outFile.Close();
            }
            catch { return false; }

            return true;
        }

        private void RecursivePAK()
        {
            //clear our lists
            m_lFiles.Clear();
            m_lFileSizes.Clear();
            //pass our PAKer our root dir
            RecursivePAK(m_szSourceDir);
        }

        private void RecursivePAK(string f_szSourceDir)
        {
            //get child directories
            string[] children = Directory.GetDirectories(f_szSourceDir);
            foreach (string szChild in children)
            {
                //call this function for each of our child directories
                RecursivePAK(szChild);
            }

            //get files in this directory
            string[] files = Directory.GetFiles(f_szSourceDir);
            FileInfo fInfo;
            foreach (string szFile in files)
            {
                //get the fileinfo so we can get the length of the file
                fInfo = new FileInfo(szFile);
                //add the files relative location to the file list 
                m_lFiles.Add(fInfo.FullName.Remove(0, m_szSourceDir.Length + 1));
                //add the size of the file to the list
                m_lFileSizes.Add((Int32)fInfo.Length);
            }
        }

        protected bool extract()
        {
            try
            {
                //turn the destination directory into an absolute directory
                DirectoryInfo dInfo = new DirectoryInfo(m_szDestDir);
                m_szDestDir = dInfo.FullName;
                //open the file for reading
                BinaryReader fileReader = new BinaryReader(File.OpenRead(m_szSourceFile));
                //check for our file header
                if (fileReader.ReadString() != m_szFileHeader)
                {
                    fileReader.Close();
                    return false;
                }
                //find out how many files we need to read
                int nFileCount = fileReader.ReadInt32();
                //generate a list of those files, and their file sizes
                for (int ia = 0; ia < nFileCount; ia++)
                {
                    m_lFiles.Add(fileReader.ReadString());
                    m_lFileSizes.Add(fileReader.ReadInt32());
                }
                FileInfo fOut;
                FileStream fOutStream;
                byte[] buffer;
                for (int ia = 0; ia < nFileCount; ia++)
                {
                    fOut = new FileInfo(m_szDestDir + "/" + m_lFiles[ia]);
                    //create our destination directory
                    if (!fOut.Directory.Exists)
                    {
                        fOut.Directory.Create();
                    }
                    //read to our buffer
                    buffer = fileReader.ReadBytes(m_lFileSizes[ia]);
                    //write to our file
                    fOutStream = fOut.OpenWrite();
                    fOutStream.Write(buffer, 0, buffer.Length);
                    fOutStream.Close();
                }
                fileReader.Close();
            }
            catch { return false; }
            return true;
        }

        protected void compress()
        {
            string NomeArquivoOriginal = this.destinationFile;
            string NomeArquivoACompactar = this.destinationFile + ".gz";

            FileStream sourceFile = File.OpenRead(NomeArquivoOriginal);
            FileStream destFile = File.Create(NomeArquivoACompactar);
            BinaryWriter b1 = new BinaryWriter(destFile);
            //inserir o cabeçalho            
            b1.Write(this.fileHeader + "Z");
            //w1.Close();
            GZipStream compstream = new GZipStream(destFile, CompressionMode.Compress);
            const int buf_size = 8192;
            byte[] buffer = new byte[buf_size];
            int bytes_read = 0;
            do
            {
                bytes_read = sourceFile.Read(buffer, 0, buf_size);
                compstream.Write(buffer, 0, bytes_read);
            } while (bytes_read != 0);

            compstream.Close();
            sourceFile.Close();
            destFile.Close();
            b1.Close();
            //apagar arquivo original
            File.Delete(destinationFile);
            //renomear arquivo gzipado para o original
            File.Move(destinationFile + ".gz", destinationFile);
        }

        protected string decompress()
        {
            string NomeArquivoCompactado = this.sourceFile;
            //cria um arquivo temporário
            string NomeArquivoADescompactar = System.IO.Path.GetTempFileName();
            FileStream sourceFile = File.OpenRead(NomeArquivoCompactado);
            BinaryReader b1 = new BinaryReader(sourceFile);
            b1.ReadString();
            FileStream destFile = File.Create(NomeArquivoADescompactar);
            GZipStream compstream = new GZipStream(sourceFile, CompressionMode.Decompress);
            int theByte = compstream.ReadByte();
            while (theByte != -1)
            {
                destFile.WriteByte((byte)theByte);
                theByte = compstream.ReadByte();
            }
            compstream.Close();
            sourceFile.Close();
            destFile.Close();
            return NomeArquivoADescompactar;
        }
    }


}
