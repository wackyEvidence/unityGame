using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }

		private Dictionary<char, Action<IVirtualMachine>> commands;
		public Dictionary<char, List<int>> bracketsIndexes;

		public VirtualMachine(string program, int memorySize)
		{
			Instructions = program;
			Memory = new byte[memorySize];
			commands = new Dictionary<char, Action<IVirtualMachine>>();
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
			commands.Add(symbol, execute);
		}
		
		public void Run()
		{
			while(InstructionPointer < Instructions.Length)
            {
				if (InstructionPointer < Instructions.Length && commands.ContainsKey(Instructions[InstructionPointer]))
					commands[Instructions[InstructionPointer]](this);

				InstructionPointer++;
			}
		}
	}
}