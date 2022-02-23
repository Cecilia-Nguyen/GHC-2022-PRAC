using System;
using System.Linq;
using System.Collections.Generic;

namespace test {
	
	class Pizza {
		
		static void Main(string[] args) {
            String[] filename={"./input_data/a_an_example.in.txt",
                "./input_data/b_basic.in.txt",
                "./input_data/c_coarse.in.txt",
                "./input_data/d_difficult.in.txt",
                "./input_data/e_elaborate.in.txt"};
            for (int number_files = 0; number_files < filename.Length; number_files++)
            {
                String[] lines = File.ReadAllLines(filename[number_files]);
                Int64 number_client=Convert.ToInt64(lines[0]);
                
                String path=filename[number_files].Replace(".in.",".out.");
                List<string> like_ingredients = new List<string>();
                List<string> dislike_ingredients = new List<string>();

                for (int i = 1; i <= number_client*2; i++)
                {
                    string[] firstArray = lines[i].Split(" ").ToArray();
                    
                    if (i%2!=0){
                        
                        for (int j = 1; j < firstArray.Length; j++)
                        { 
                            if (like_ingredients.Contains(firstArray[j])==false)
                            {
                                like_ingredients.Add(firstArray[j]);
                            }
                            
                        }
                    }else{
                        for (int k = 1; k < firstArray.Length; k++)
                        { 
                            if (dislike_ingredients.Contains(firstArray[k])==false)
                            {
                                dislike_ingredients.Add(firstArray[k]);
                            }
                            
                        }
                    }
                }
                for (int num = 0; num< dislike_ingredients.Count; num++)
                {
                    like_ingredients.Remove(dislike_ingredients[num]);
                }
                like_ingredients.Sort();
                
                using (StreamWriter writer = File.CreateText(path)) {
                writer.Write(like_ingredients.Count+" ");
                for (int n = 0; n < like_ingredients.Count; n++)
                { 
                    writer.Write(like_ingredients[n]+" ");
                }
            }
         
            }
			   
		}
	}
}
