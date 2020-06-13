using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Project1;

namespace DataStructures_Algorithms.Project2
{
    class HuffmanTree
    {
        public HuffmanNode Root { get; set; }

        // CodeTable is a Dictionary in which each row contains a pair of information
        // - Key: a letter, e.g. "a"
        // - Value: Huffman code, e.g. "000"
        // For example, an element of CodeTable should look like <'A', "000">
        public Dictionary<char, string> CodeTable { get; set; }

        public HuffmanTree() { Root = null; }

        private void CreateNodes(ref List<HuffmanNode> Nodes, Vector<char> Input)
        {
            Nodes = new List<HuffmanNode>();
            for (int i = 0; i < Input.Count; i++)
            {
                // check if input[i] exists
                int j;
                for (j = 0; j < Nodes.Count; j++)
                {
                    if (Nodes[j].Value.Equals(Input[i]))
                        break;
                }
                if (j < Nodes.Count)
                    Nodes[j].Frequency++;
                else
                    Nodes.Add(new HuffmanNode(Input[i], 1));
            }
        }

        private void Sort(ref List<HuffmanNode> Nodes)
        {
            //Nodes = new List<HuffmanNode>();
            Nodes.Sort();


        }

        private void Build(ref List<HuffmanNode> Nodes)
        {
          

            while (Nodes.Count > 1)
            {
                
                if(Nodes.Count >= 2)
                {
                    //take first two items
                    List<HuffmanNode> taken = Nodes.Take(2).ToList<HuffmanNode>();

                    //Create a parent node by cobining the frequencies
                    HuffmanNode parent = new HuffmanNode(' ',0)
                    {
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        LeftChild = taken[0],
                        RightChild = taken[1]

                    };

                    Nodes.Remove(taken[0]);
                    Nodes.Remove(taken[1]);
                    Nodes.Add(parent);
                   



                }


                this.Root = Nodes.FirstOrDefault();




            }



        }

        private void ConstructCodeTable()
        {
           
            CodeTable = new Dictionary<char, string>();
            CodeTable.Add('A', "");
            CodeTable.Add('B', "");
            CodeTable.Add('C', "");
            CodeTable.Add('D', "");
            CodeTable.Add('E', "");
           

           List<bool> data = new List<bool>();
            
            foreach (char letter in CodeTable.Keys.ToList())
            {


               
                data =  Root.Traverse(letter, new List<bool>());
                StringBuilder output = new StringBuilder();
                foreach(bool item in data)
                {

                    output.Append(item ? "1" : "0");

                }
                string codename = output.ToString();
                
                CodeTable[letter] = codename;
                     


            }


        }

        public void Encode(Vector<char> Input)
        {
            // create a list of nodes.
            // each node corresponds to a letter and associated with the frequency
            List<HuffmanNode> Nodes = null;
            CreateNodes(ref Nodes, Input);

            // sort the list Nodes in ascending order of frequency
            Sort(ref Nodes);

            // construct the Huffman tree
            Build(ref Nodes);

            // construct CodeTable
            ConstructCodeTable();
        }

        // this method aims to decode a string code
        // for example, Decode("000") could return 'A'
        public char Decode(string Code)
        {
            char[] keysByValue = CodeTable.Where(x => x.Value == Code).Select(pair => pair.Key).ToArray();
            string chara;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var i in keysByValue)
            {
                sb.Append("").Append(i).Append("");

            }
            chara = sb.ToString();

            char character = char.Parse(chara);
            return character;
        }


       









    }
}