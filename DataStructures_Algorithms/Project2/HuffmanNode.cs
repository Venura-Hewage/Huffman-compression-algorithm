using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Project2
{
    class HuffmanNode : IComparable<HuffmanNode>
    {
        public char Value { get; set; }
        public double Frequency { get; set; }
        public string Code { get; set; }

        public HuffmanNode LeftChild { get; set; }
        public HuffmanNode RightChild { get; set; }

        // this is used for leaf nodes
        public HuffmanNode(char Value, double Frequency = 0)
        {
            this.Value = Value;
            this.Frequency = Frequency;
            this.LeftChild = this.RightChild = null;
            this.Code = "";
        }

        // this is used for internal nodes (i.e. non-leaf nodes)
        public HuffmanNode(HuffmanNode LeftChild, HuffmanNode RightChild)
        {
            this.LeftChild = LeftChild;
            this.RightChild = RightChild;
            this.Frequency = this.LeftChild.Frequency + this.RightChild.Frequency;
            this.Code = "";
        }

        public int CompareTo(HuffmanNode compareNode)
        {

            if(compareNode == null)
            {
                return 1;
            }

            else
            {
                return this.Frequency.CompareTo(compareNode.Frequency);
            }
            

        }


        public List<bool> Traverse(char character , List<bool> data)
        {
            //check the leafs for existing characters
             
            if(LeftChild == null &&  RightChild == null)
            {

                if(Value.Equals(character))
                {

                    return data;
                }

                else
                {
                    return null;
                }



               
                

            }
            else
            {

                List<bool> left = null;
                List<bool> right = null;


                 if(LeftChild != null)
                {
                    List<bool> leftpath = new List<bool>(data);
                    leftpath.Add(false); //Add a '0'
                    left = LeftChild.Traverse(character, leftpath); //recursive traversal for child nodes within the left node
                  

                }


                if ( RightChild != null)
                {
                    List<bool> rightpath = new List<bool>(data);
                    rightpath.Add(true); // Add a 'A'
                    right = RightChild.Traverse(character, rightpath);



                }

                return (left != null) ? left : right;

            }









        }






    }
}