using ProjetoCalculaSalario.Entities;
using ProjetoCalculaSalario.Entities.Enum;
using System.Globalization;


namespace ProjetoCalculaSalario
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            Department dep = new Department();
            HourContract contract = new HourContract();

            // PEDE O DEPARTAMENTO
            Console.Write("Enter department's name: ");
            dep.Name = Console.ReadLine();

            // PEDE OS DADOS DO TRABALHADOR
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            worker.Name = Console.ReadLine();

            // PEDE O NIVEL DO TRABALHADOR
            Console.Write("Level (Junior/MidLevel/Senior): ");
            string input = Console.ReadLine();

            // VERIFICA SE O NIVEL DO TRABALHADOR É VALIDO
            while (!Enum.TryParse(input, true, out WorkerLevel level))
            {
                Console.WriteLine("Please, insert: 'Junior', 'MidLevel' or 'Senior'.");
                input = Console.ReadLine();
            }
            worker.Level = Enum.Parse<WorkerLevel>(input);

            // PEDE O SALARIO BASE DO TRABALHADOR
            Console.Write("Base salary: ");
            worker.BaseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // PEDE QUANTOS CONTRATOS O TRABALHADOR TEM
            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            // PEDE OS DADOS DOS CONTRATOS
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter #{i + 1} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                worker.addContract(new HourContract(date, valuePerHour, hours));
            }

            // PEDE O MES E O ANO PARA CALCULAR O SALARIO
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3, 4));
           
            // IMPRIME OS DADOS
            Console.WriteLine();
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {dep.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month)}");



        }
    }
}