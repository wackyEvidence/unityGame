using System;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
		public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
			vm.RegisterCommand('.', b => write((char)b.Memory[b.MemoryPointer]));
			vm.RegisterCommand('+', b => { unchecked { b.Memory[b.MemoryPointer]++ ;} });
			vm.RegisterCommand('-', b => { unchecked { b.Memory[b.MemoryPointer]-- ;} });
			vm.RegisterCommand(',', b => b.Memory[b.MemoryPointer] = (byte)read());
			vm.RegisterCommand('>', b => 
			{ 
				b.MemoryPointer++;
				b.MemoryPointer = b.MemoryPointer >= b.Memory.Length ? b.MemoryPointer % b.Memory.Length : b.MemoryPointer; 
			});
			vm.RegisterCommand('<', b => 
			{ 
				b.MemoryPointer--;
				b.MemoryPointer = b.MemoryPointer < 0 ? b.Memory.Length + b.MemoryPointer : b.MemoryPointer; 
			});
            foreach (var sign in "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
				vm.RegisterCommand(sign, b => b.Memory[b.MemoryPointer] = (byte)sign);
        }
	}
}