using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace Ex.InterpolatedString
{
    /// <summary>
    /// 文字列挿入に渡すパラメータ
    /// </summary>    
    public class Globals
    {
        public int foo;
        public string bar;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string formattable = "foo={foo} bar={bar}";
            Print(formattable).Wait();
        }

        static async Task Print(string formattable)
        {
            var foo = 123;
            var bar = "abc";

            var code = $"return $\"{formattable}\";"; // C#コード作成
            var globals = new Globals { foo = foo, bar = bar };
            var result = await CSharpScript.EvaluateAsync<string>(code, globals: globals);

            Console.WriteLine(result);
        }
    }
}
