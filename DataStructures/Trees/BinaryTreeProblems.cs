namespace TOMICZ.DSARunner.Trees
{
    public class BinaryTreeProblems
    {
        public string ReverseStringRecursevely(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }

            return ReverseStringRecursevely(input.Substring(1)) + input[0];
        }
    }
}