using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_pattern
{
    internal class Program
    {
        public interface IComponent
        {
            string Name { get; }
            void ShowDetails();
        }
        public class CPU : IComponent
        {
            public string Name { get; private set; }
            public CPU(string name)
            {
                Name = name;
            }
            public void ShowDetails()
            {
                Console.WriteLine($"CPU: {Name}");
            }
        }
        public class RAM : IComponent
        {
            public string Name { get; private set; }
            public RAM(string name)
            {
                Name = name;
            }
            public void ShowDetails()
            {
                Console.WriteLine($"RAM: {Name}");
            }
        }
        public class HDD : IComponent
        {
            public string Name { get; private set; }
            public HDD(string name)
            {
                Name = name;
            }
            public void ShowDetails()
            {
                Console.WriteLine($"HDD: {Name}");
            }
        }
        public class Computer : IComponent
        {
            private List<IComponent> _components = new List<IComponent>();
            public string Name { get; private set; }
            public Computer(string name)
            {
                Name = name;
            }
            public void AddComponent(IComponent component)
            {
                _components.Add(component);
            }
            public void ShowDetails()
            {
                Console.WriteLine($"Computer: {Name}");
                foreach (var component in _components)
                {
                    component.ShowDetails();
                }
            }
        }
        public interface IComputerBuilder
        {
            void AddCPU();
            void AddRAM();
            void AddHDD();
            Computer GetComputer();
        }
        public class GamingComputerBuilder : IComputerBuilder
        {
            private Computer _computer;
            public GamingComputerBuilder()
            {
                _computer = new Computer("Gaming Computer");
            }
            public void AddCPU()
            {
                _computer.AddComponent(new CPU("AMD Ryzen 9 7950X3D"));
            }
            public void AddRAM()
            {
                _computer.AddComponent(new RAM("64GB RAM"));
            }
            public void AddHDD()
            {
                _computer.AddComponent(new HDD("2TB SSD"));
            }
            public Computer GetComputer()
            {
                return _computer;
            }
        }
        public class OfficeComputerBuilder : IComputerBuilder
        {
            private Computer _computer;
            public OfficeComputerBuilder()
            {
                _computer = new Computer("Office Computer");
            }
            public void AddCPU()
            {
                _computer.AddComponent(new CPU("Intel Pentium E2140"));
            }
            public void AddRAM()
            {
                _computer.AddComponent(new RAM("8GB RAM"));
            }
            public void AddHDD()
            {
                _computer.AddComponent(new HDD("500GB HDD"));
            }
            public Computer GetComputer()
            {
                return _computer;
            }
        }
        public class ComputerDirector
        {
            private IComputerBuilder _builder;

            public ComputerDirector(IComputerBuilder builder)
            {
                _builder = builder;
            }

            public void ConstructComputer()
            {
                _builder.AddCPU();
                _builder.AddRAM();
                _builder.AddHDD();
            }

            public Computer GetComputer()
            {
                return _builder.GetComputer();
            }
        }
        static void Main(string[] args)
        {
            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            ComputerDirector director = new ComputerDirector(gamingBuilder);
            director.ConstructComputer();
            Computer gamingComputer = director.GetComputer();
            gamingComputer.ShowDetails();
            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            director = new ComputerDirector(officeBuilder);
            director.ConstructComputer();
            Computer officeComputer = director.GetComputer();
            officeComputer.ShowDetails();
        }
    }
}
