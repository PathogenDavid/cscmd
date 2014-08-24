using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace cscmd
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Usage: cscmd scriptFile.cs [arguments]");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.Error.WriteLine("Script file not found.");
                return;
            }

            CSharpCodeProvider compiler = new CSharpCodeProvider();

            //Default references for a C# command line project in Visual Studio 2012:
            string[] references = new string[] {
                "Microsoft.CSharp.dll",
                "System.dll",
                "System.Core.dll",
                "System.Data.dll",
                "System.Data.DataSetExtensions.dll",
                "System.Xml.dll",
                "System.Xml.Linq.dll"
            };

            CompilerParameters compilerParameters = new CompilerParameters(references);
            compilerParameters.GenerateExecutable = true;
            compilerParameters.GenerateInMemory = true;
            compilerParameters.WarningLevel = 3;

            CompilerResults results = compiler.CompileAssemblyFromFile(compilerParameters, args[0]);

            if (results.Errors.Count > 0)
            {
                Console.Error.WriteLine("Script was not build successfully.");
                foreach (CompilerError error in results.Errors)
                {
                    Console.Error.WriteLine("    " + error.ToString());
                }
                return;
            }

            if (results.CompiledAssembly.EntryPoint == null)
            {
                Console.Error.WriteLine("No suitable entry-point found!");
                return;
            }

            string[] scriptArgs = new string[args.Length - 1];
            Array.Copy(args, 1, scriptArgs, 0, scriptArgs.Length);
            results.CompiledAssembly.EntryPoint.Invoke(null, new object[] { scriptArgs });
        }
    }
}
