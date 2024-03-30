# CS_Rental_Service

<p align="center">
  <img width="460" height="300" src="/cs_rentalLogo.png">
</p>

O CS Rental Service é um projeto em C# desenvolvido para gerenciar serviços de aluguel de carros. Este sistema permite que os usuários cadastrem clientes, carros e lidem com aluguéis e devoluções de carros.

## Funcionalidades

- Registro de cliente: Adicionar novos clientes pessoa física (individual) ou empresas ao sistema (company).
- Registro de carro: Cadastrar novos carros com detalhes como placa, modelo, categoria e tarifa.
- Alugar um carro: Processar aluguéis de carros para clientes individuais e empresas, incluindo especificar datas de retirada e devolução, forma de pagamento e detalhes adicionais.
- Buscar contratos: Pesquisar contratos de aluguel pelo número do contrato.
- Devolver um carro: Encerrar um contrato de aluguel devolvendo o carro e fechando o contrato.

## Estrutura do Projeto

O projeto consiste em várias classes principais:

### 1. Client_Register

A classe Client_Register gerencia o registro de clientes, incluindo adição, remoção, busca e exibição de clientes. Ela contem os seguintes métodos:

- `AddClient(Cliente cliente)`: Adiciona um novo cliente ao registro.
- `RemoveClient(int id)`: Remove um cliente do registro com base no ID.
- `FindById(int id)`: Procura e retorna um cliente pelo ID.
- `FindContract(int contractNumber)`: Procura e retorna um contrato de aluguel pelo número do contrato.
- `ReturnCar(int contractNumber, Car_Register carRegister)`: Encerra um contrato de aluguel, marcando o carro como devolvido.

### 2. Car_Register

A classe Car_Register lida com o registro de carros, incluindo adição, remoção, busca por placa ou modelo e exibição de carros de acordo com a lista de funções abaixo:

- `AddCar(Car car)`: Adiciona um novo carro ao registro.
- `RemoveCar(string licensePlate)`: Remove um carro do registro com base na placa.
- `FindByLicensePlate(string licensePlate)`: Procura e retorna um carro pela placa.
- `FindByModel(string model)`: Procura e retorna carros por modelo.

### 3. Individual_Rental e Company_Rental

Essas classes representam aluguéis de carros individuais e corporativos, respectivamente. Elas gerenciam contratos de aluguel, incluindo detalhes como número do contrato, ID do cliente, datas, forma de pagamento e informações adicionais específicas para cada tipo de aluguel.

### 4. Program

A classe Program contém a lógica principal do aplicativo, incluindo o menu interativo. É a classe principal que contém o método Main. Ela interage com o usuário por meio de um menu interativo que oferece opções para acessar diferentes funcionalidades do sistema, como registro de clientes, registro de carros, aluguel de carros, busca de contratos e devolução de carros. A interação com o usuário ocorre principalmente por meio do console, onde são exibidas mensagens e solicitações para entrada de dados.

A classe Program possui métodos auxiliares como:

- `ValidateOption()`: Valida uma opção de menu para garantir que esteja dentro dos limites aceitáveis.
- `ValidateChar()`: Valida se o caractere inserido é 'c' ou 'i', permitindo ao sistema diferenciar se o contrato é pessoa física ou jurídica.
- `Summary()`: Gera um resumo do contrato de aluguel para exibição ao usuário antes de finalizá-lo, para que o usuário confira e informe se está de acordo.
- `CheckAnswer()`: Valida se a resposta do usuário é 'y' ou 'n', o que evita do usuário fornecer respostas incorretas.

Dentro do loop principal (do-while) do método Main, o programa continua executando até que o usuário escolha a opção de saída. Cada opção do menu aciona um conjunto específico de ações que interagem com as outras classes do sistema para realizar as operações desejadas. As exceções são tratadas para lidar com possíveis erros durante a execução do programa, fornecendo mensagens de erro informativas ao usuário.

## Contribuições

Contribuições são bem-vindas! Se você encontrar um problema ou tiver alguma sugestão de melhoria, sinta-se à vontade para abrir uma issue ou enviar um pull request.









