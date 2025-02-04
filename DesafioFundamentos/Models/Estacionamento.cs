namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            //Pede para o usuário digitar uma placa (ReadLine), valida que o input do usuário não é nulo e adiciona na lista "veiculos"

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!string.IsNullOrEmpty(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine("Veículo adicionado.");
            }
        }

        public void RemoverVeiculo()
        {
            string placa = " ";
            Console.WriteLine("Digite a placa do veículo para remover:");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                placa = input;

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    int horas = 0;
                    decimal valorTotal = 0;

                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    input = Console.ReadLine();

                    if (!string.IsNullOrEmpty(input))
                    {
                        bool sucesso = int.TryParse(input, out horas);

                        if (sucesso)
                        {
                            valorTotal = precoInicial + precoPorHora * horas;
                            veiculos.Remove(placa);

                            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                        }
                        else { Console.WriteLine("Valor inválido."); }
                    }
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

