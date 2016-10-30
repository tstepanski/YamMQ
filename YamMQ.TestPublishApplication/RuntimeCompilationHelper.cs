using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
using YamMQ.General.Types;

namespace YamMQ.TestPublishApplication
{
    public static class RuntimeCompilationHelper
    {
        public static IEnumerable<IMessage> CreateMessages(string userEnteredCode)
        {
            var assembly = CompileAssembly(userEnteredCode);
            var typesImplementingIMessage = GetTypesImplementingIMessage(assembly);
            var messages = typesImplementingIMessage.Select(CreateInstanceOfMessageType);

            return messages;
        }

        private static Assembly CompileAssembly(string code)
        {
            var cSharpCodeProvider = new CSharpCodeProvider(new Dictionary<string, string> {{"CompilerVersion", "v4.0"}});

            var parameters = new CompilerParameters(new[] {"mscorlib.dll", "System.Core.dll", "YamMQ.General.dll"});

            var results = cSharpCodeProvider.CompileAssemblyFromSource(parameters, code);

            var compilationErrors = results
                .Errors
                .Cast<CompilerError>()
                .Select(error => error.ErrorText)
                .Aggregate(new StringBuilder(), (previous, next) => previous.AppendLine(next))
                .ToString();

            if (!string.IsNullOrWhiteSpace(compilationErrors))
            {
                throw new Exception($"Failed to compile type: {compilationErrors}");
            }

            return results.CompiledAssembly;
        }

        private static IEnumerable<Type> GetTypesImplementingIMessage(Assembly assembly) => assembly
            .GetTypes()
            .Where(DoesTypeImplementsIMessage);

        private static IMessage CreateInstanceOfMessageType(Type type) => (IMessage) Activator.CreateInstance(type);

        private static bool DoesTypeImplementsIMessage(Type type)
        {
            return type
                .GetInterfaces()
                .Any(implementedInterface => implementedInterface == typeof(IMessage));
        }
    }
}