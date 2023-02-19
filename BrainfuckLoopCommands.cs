using System.Collections.Generic;

namespace func.brainfuck
{
	public class BrainfuckLoopCommands
	{
		public static void RegisterTo(IVirtualMachine vm)
		{
			var openBracketsStack = new Stack<int>(); 
			var openBracketsIndexes = new Dictionary<int, int>(); 
			var closingBracketsIndexes = new Dictionary<int, int>(); 

			for (int i = 0; i < vm.Instructions.Length; i++)
			{
				if (vm.Instructions[i] == '[')
                {
					openBracketsIndexes.Push(i);
                }

				else if (vm.Instructions[i] == ']')
                {
					closingBracketsIndexes.Push(i);
                }
			}

			vm.RegisterCommand('[', b => 
			{
				// ���� ������� ������ ������ ����� 0, �� ����������� �� ����� ����� ], ����� ���������� � ����� �������
				var currentIndex = b.InstructionPointer;

				if(b.Memory[b.MemoryPointer] == 0)
                {
                    

                }
			});

			vm.RegisterCommand(']', b => 
			{
				// ���� ������� ������ ������ �� ����� 0, �� ����������� � ������ ����� [, ����� ���������� � ����� �������
				var currentIndex = b.InstructionPointer;
				if (b.Memory[b.MemoryPointer] != 0)
				{
					
				}
			});
		}
	}
}