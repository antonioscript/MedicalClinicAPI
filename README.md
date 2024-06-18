# MedicalClinicAPI
MedicalClinicAPI is a RESTful API designed to manage medical clinic operations and patient records. It provides a comprehensive set of endpoints to handle patient information, doctor details, appointment scheduling, medical history, prescriptions, and more
<p align="center">
  <img src="https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/90cb77bb-f55d-455d-acf7-516608ad97dd.png" alt="Medical Clinic">
</p>

## Keep Up With the Latest Updates on This Project
The project is currently under development. You can follow all new features, updates, and implementations by clicking here: </br>
[Project Repository](https://github.com/users/antonioscript/projects/2?pane=info)

# Índice
- [Features](#features)
  - [Cadastro de Especialidades](#Cadastro-de-Especialidades)
  - [Cadastro de Médicos](#Cadastro-de-Médicos)
  - [Cadastro de Disponibilidade Médica](#Cadastro-de-Disponibilidade-Médica)
  - [Cadastro de Pacientes](#Cadastro-de-Pacientes)
  - [Agendamento](#Agendamento)
  - [Cancelar Agendamento](#Cancelar-Agendamento)
  - [Prescrição Médica](#Prescrição-Médica)
  - [Cadastro de Exames](#Cadastro-de-Exames)
  - [Cadastro de Técnicos](#Cadastro-de-Técnicos)
  - [Procedimentos](#Procedimentos)
    
- [Arquitetura](#arquitetura)
  - [Banco de Dados](#Banco-de-Dados)
  - [Abordagem Database First](#Abordagem-Database-First)
  - [Modelo do Banco de Dados](#Modelo-do-Banco-de-Dados)
  - [Visualização da API](#Visualização-da-API)
  - [ORM](#ORM)
  - [Arquitetura de Código](#Arquitetura-de-Código)
     - [Domain](#Domain)
     - [Infrastructure](#Infrastructure)
     - [Application](#Application)
     - [Presentation](#Presentation)
  - [Repository Pattern](#Repository-Pattern)
  - [CQRS (Command Query Responsibility Segregation)](#cqrs-command-query-responsibility-segregation)
  - [Mediator Pattern](#Mediator-Pattern)
  - [Unit of Work](#Unit-of-Work)

# Features

## Cadastro de Especialidades
Um dos cadastros essenciais da aplicação é o cadastro de especialidades. São as especialidades que informam quais são as áreas de atuação que Clínica Médica trabalha.

No cadastro de especialidades deve ser informado o nome da especialidade, o valor da consulta, bem como a duração médida da consulta (que será usada em cálculos posteriores para o agendamento adequeado).

</br>![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/17df3dd1-f680-4a67-99db-36a88ba24fab)


## Cadastro de Médicos
Após o cadastro de especialidades, o próximo cadastro da aplicação é o cadastro de Médicos. 

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/327ff8ac-e15f-4159-b81b-3fa9d3475646)

Para o cadastro de um médico, é inserido a especialidade do médico, nome e sobrenome, endereço, e o CRM (Código do Conselho Regional de Medicina), que trata-se de um identificador único de cada médico. 

## Cadastro de Disponibilidade Médica 
Um outro cadastro importante que está associado aos médicos, é o cadastro de disponibilidade. Nesse cadastro são inseridas informações relativas ao turno de trabalho dos médicos, como o dia da semana e o horário de atendimento.

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/48c17b56-7eeb-4fdf-aad3-007392400b7b)

## Cadastro de Pacientes
Para que um atendimento seja realizado é necessário também que os pacientes estejam cadastrados. As informações de entrada dos pacientes são: plano de saúde (se o paciente tiver), nome e sobrenome, documento, data de aniversário, telefone, email e endereço

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/f50317cd-44d3-4adc-bc2a-3f1972d7606a)

## Agendamento
Após os cadastros relacionados ao médico e o paciente estarem preenchidos, inicia-se então o agendamento com as informações do paciente, médico, data de agendamento, o status do agendamento (que pode ser agendado, confirmado, cancelado e concluído) e observação. No agendamento também existe um campo opcional de encaminhamento, que é quando um médico de uma outra consulta faz o encaminhamento do paciente.  

Exemplo de respota de um agendamento:

``` JSON
{
  "data": {
    "id": 1,
    "requestingDoctorId": null,
    "requestingDoctor": null,
    "patientId": 1,
    "patient": {
      "id": 1,
      "insuranceId": 1,
      "insurance": null,
      "insuranceType": 1,
      "firstName": "John",
      "lastName": "Doe",
      "document": "123456789",
      "dateOfBirth": "1990-05-15T00:00:00",
      "gender": 1,
      "phoneOne": "+1 (123) 456-7890",
      "phoneTwo": "+1 (987) 654-3210",
      "email": "john.doe@email.com",
      "addressLineOne": "123 Main Street",
      "addressLineTwo": "Apt 4B",
      "isEnabled": true
    },
    "doctorId": 1,
    "doctor": {
      "id": 1,
      "specialtyId": 1,
      "specialty": null,
      "crm": "12345",
      "firstName": "John",
      "lastName": "Smith",
      "phone": "+1 (123) 456-7890",
      "email": "john.smith@email.com",
      "addressLineOne": "123 Main Street",
      "addressLineTwo": "Apt 4B",
      "isEnabled": true,
      "availabilities": []
    },
    "appointmentDate": "2023-01-15T09:00:00",
    "status": 1,
    "observation": "Regular check-up",
    "isEnabled": true
  },
  "failed": false,
  "message": null,
  "succeeded": true,
  "errors": null
}
``` 

## Cancelar Agendamento
Para os agendamentos que são cancelados, existe uma tabela onde é armanezada todos os agendamentos que foram cancelados e também o motivo do cancelamento. Ao fazer isso, a API atribui atuomaticamente o status de 'Cancelado' para o agendamento.

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/fbdc8ce7-0d5f-42b0-ae16-a8d71ba0290d)


## Prescrição Médica
Marcado um agendamento, inicia-se a consulta, que é o coração do sistema. Na consulta após os relatos e análise do paciente, o médico cria uma prescrição. A prescrição é todo o resumo da consulta, bem como orientações médicas e remédios aconselhados para o paciente. Após uma prescrição ser gerada, o agendamento recebe o status de 'Concluído' automaticamente.


Exemplo de um JSON de uma prescrição médica:

```JSON
{
  "data": {
    "id": 1,
    "appointmentId": 1,
    "appointment": null,
    "observation": "Discovered elevated blood pressure during examination. Recommend monitoring and lifestyle changes.",
    "medications": [
      {
        "id": 1,
        "prescriptionId": 1,
        "name": "Ibuprofen",
        "substituteOne": "Acetaminophen",
        "substituteTwo": "Naproxen",
        "instruction": "Take one tablet every 6 hours with food."
      }
    ],
    "forwardings": [
      {
        "id": 1,
        "prescriptionId": 1,
        "specialtyId": 1,
        "specialty": {
          "id": 1,
          "name": "Cardiology",
          "description": "Deals with disorders of the heart and blood vessels.",
          "consultationValue": 250,
          "appointmentDuration": 0,
          "isEnabled": true
        },
        "observation": "Forwarded prescription to cardiology for further evaluation."
      }
    ]
  },
  "failed": false,
  "message": null,
  "succeeded": true,
  "errors": null
}
```

Na consulta médica podemos perceber que existe o campo de observação, que é o local adequado para o médico descrever o parecer geral do paciente, ou seja, os sintomas e problemas que o paciente está enfrentando e temos também as medicações, que são os remédios recomendados pelo médico. Perceba que para cada medicação existem campos opcionais de remédios substituos, para o caso de medicamentos similares que contém o mesmo efeito, que são os casos dos medicamentos genéricos. 

E por último, informações relativas a um possível encaminhamento, caso o médico perceba que o paciente precisa de uma outra especialidade para tratar o problema. 


## Cadastro de Exames
Um outro cadastro que pode acontecer em paralelo com o fluxo de agendamento é o cadastro de exames. Os exames são outro tipo de serviço que existe na clínica, além das consultas que acontecem por padrão com os médicos. Que engloba os exames laboratoriais e de imagem que os pacientes podem precisar realizar como parte de seu tratamento ou diagnóstico, ou apenas de forma isolada. 

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/6aab06a2-7c2c-4433-8db2-fc03adf4d2e6)

## Cadastro de Técnicos
Para realizar os exames, é preciso de um técnico cadastrado. O cadastro de técnicos no sistema é essencial para garantir que os exames sejam realizados por profissionais capacitados e registrados. Os técnicos são responsáveis por operar os equipamentos, coletar amostras, e realizar procedimentos específicos de cada exame.

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/7653cfaa-4267-4747-a6af-978e29406dfa)

## Procedimentos
Os procedimentos são de fato a realização do exame, feita pelo técnico junto com o paciente. No procedimento contém as informações do paciente, do técnico , do exame, data de realização daquele exame e uma observação geral sobre o procedimento.

Exemplo de Resposta de um procedimento: 


``` JSON
{
  "data": {
    "id": 1,
    "patientId": 1,
    "patient": {
      "id": 1,
      "insuranceId": 1,
      "insurance": null,
      "insuranceType": 1,
      "firstName": "John",
      "lastName": "Doe",
      "document": "123456789",
      "dateOfBirth": "1990-05-15T00:00:00",
      "gender": 1,
      "phoneOne": "+1 (123) 456-7890",
      "phoneTwo": "+1 (987) 654-3210",
      "email": "john.doe@email.com",
      "addressLineOne": "123 Main Street",
      "addressLineTwo": "Apt 4B",
      "isEnabled": true
    },
    "technicianId": 1,
    "technician": {
      "id": 1,
      "firstName": "Robert",
      "lastName": "Johnson",
      "email": "robert.johnson@example.com",
      "phone": "+1 (123) 456-7890",
      "addressLineOne": "123 Main Street",
      "addressLineTwo": "Apt 4B",
      "insuranceType": 1,
      "isEnabled": true
    },
    "examId": 1,
    "exam": {
      "id": 1,
      "name": "Blood Test",
      "description": "Basic blood analysis",
      "value": 80,
      "isEnabled": true
    },
    "observation": "Routine blood test",
    "procedureDate": "2024-01-20T17:37:12.357",
    "status": 0,
    "isEnabled": true
  },
  "failed": false,
  "message": null,
  "succeeded": true,
  "errors": null
}
``` 

# Arquitetura
A arquitetura deste projeto consiste em uma API Rest desenvolvida com o framework .NET na versão 6, utilizando o banco de dados SQL Server e Docker para facilitar a implantação e o gerenciamento de contêineres.

## Banco de Dados
O banco de dados escolhido para a aplicação foi o SQL Server, por conta de sua performance e integração nativa com ecossistemas Microsoft, o que agiliza bastante o desenvolvimento e o uso de outras ferramentas como o Visual Studio. 

## Abordagem Database First
Para desenvolver a API, foi adotada a abordagem "Database First", que se concentra na criação inicial do banco de dados. Nessa abordagem, o design e a estrutura do banco de dados são definidos antecipadamente, e a partir dele, o código da aplicação é gerado. Garantindo que o modelo de dados esteja bem definido e otimizado antes de iniciar o desenvolvimento da aplicação.

Essa abordagem foi escolhida para refletir a realidade das aplicações de grande porte, onde o banco de dados muitas vezes já existe há bastante tempo e é compartilhado por várias aplicações, incluindo sistemas de terceiros. Optar por essa abordagem garante que a integração com esses bancos de dados seja mais fluida, aproveitando a estrutura já existente e assegurando a consistência e a compatibilidade entre as diversas aplicações que utilizam o mesmo banco de dados.

## Modelo do Banco de Dados
Atualmente esse é o modelo do banco de dados mais recente da aplicação:

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/6c57772b-0b09-4f2d-bd76-e3501731be5c)
<sub>Data da última atualização: *15/06/2024*</sub>

## Visualização da API
Para visualizar a API, foi escolhida a utilização do Swagger, uma ferramenta que oferece uma interface intuitiva sem a necessidade de instalar ferramentas adicionais para testar e executar a aplicação. Além disso, o Swagger simplifica o processo de documentação, gerando automaticamente a documentação a partir do código-fonte da aplicação.

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/b028353a-311f-4617-b82a-be685b1ced85)
<sub>Data da última atualização: *15/06/2024*</sub>

## ORM
Para fazer a comunicação da aplicação com o banco de dados, o framework escolhido foi o Entity Framework Core, que é um framework da própria Microsoft, que facilita bastante a integração usando objetos do .NET. Além de ser responsável pelo relacionamento com o banco, o Entity Framewok Core conta com um recurso muito rico, chamado LINQ. Que permite escrever queries SQL usando C# de forma simples, aumentando assim a performance e produtividade no desenvolvimento.

## Arquitetura de Código
A arquitetura de código escolhida foi a arquitetura 'Clean Architecture', que é um tipo de arquitetura bastante moderna, que foi idealizada pelo Uncle Bob. O objetivo dessa arquitetura é promover a separação de preocupações e a manutenção da independência entre as diferentes camadas da aplicação, divindido-as entre: Domínio, Aplicação, Infraestrutura e Apresentação.

No projeto a Clean Architecture foi adaptada dessa forma:

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/4c23a8b1-7784-4aef-b1c4-658035e2e09d)

Onde podemos visualizar as camadas de domínio, aplicação, infraestrutura e apresentação. 

### Domain
Na cama de domínio, no centro da arquitetura, estão as entidades. As entidades representam os conceitos centrais da aplicação, é a unidade básica do sistema. 

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/5476a828-62e1-47a9-89ff-20c7e56338f5)

Além das entidades, também temos os Enums dessas entidades, que são objetos auxiliares de dados específicos das entidades.

### Infrastructure
Como o próprio nome já diz, na infraestrutura alocamos tudo aquilo que é essencial para a estrutura do sistema, como as configurações do banco, extensões, os repositórios e tudo aquilo que é compartilhado para toda a API.

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/3acbe4ac-331d-4120-b896-83794c9c74bb)


### Application
Para a camada de aplicação estão as regras de negócio e tudo aquilo que é responsável para a lógica do sistema. Na cama de aplicação estão presentes os casos de usos, os handlers, os DTOs e  as regras de negócio.

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/4b36a2f6-e6cb-4bfb-9c87-6a5162846a55)

### Presentation
E para a cama de apresentação, está presente tudo aquilo que faz a ligação dos dados entre servidor e cliente, que no caso da API, são os Controllers, responsáveis por forneceer os endpoints da aplicação.

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/d319e8eb-db3b-4c27-a42b-13d2088e8c4a)

## Repository Pattern
Um dos Design Patterns utilizado na aplicação foi o Repository Pattern, que consiste em separar as camadas de acesso dos dados e a lógica de negócios, proporcionando uma abstração na fonte dos dados, fazendo que a camada da lógica de negócios seja independente das outras camadas.

Para o projeto em questão, foi utilizado uma interface abstrata, usando os conceitos de Generics, onde essa interface consiste em abstrair métodos genéricos que serão utilizados por todas as entidades da API. Esses métodos consistem nas aplicações básicas como Create, Read, Update e Delete. 

``` Csharp
namespace MedicalClinic.Application.Interfaces.Repositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
```
<sub>*src\api\MedicalClinic.Application\Interfaces\Repositories\IRepositoryAsync.cs*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.Application/Interfaces/Repositories/IRepositoryAsync.cs)</sub>



O objetivo de se utilizar o Repository Pattern vai além do simples fato de reduzir a duplicidade de código, ele oculta os detalhes de como os dados são persistidos e recuperados, sem que a lógica de negócios conheça os detalhes da implementação, tornando assim o código mais flexível. 

Para a invocação do repositório, cada entidade herda as configurações da classe interface genérica, que também é o um lugar de criar algum método específico daquela entidade em questão:

``` csharp
public interface IDoctorRepository : IRepositoryAsync<Doctor>
{
}
```

<sub>*src\api\MedicalClinic.Application\Interfaces\Repositories\Entities\IRefreshTokenRepository.cs*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.Application/Interfaces/Repositories/Entities/IRefreshTokenRepository.cs)</sub>



E para a implementação dessa interface, que é onde de fato ocorre a lógica de acesso ao banco de dados, foi criado uma classe de repositório com os detalhes dessa aplicação:

``` csharp
namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IRepositoryAsync<Doctor> _repository;
        public DoctorRepository(IRepositoryAsync<Doctor> repository)
        {
            _repository = repository;
        }

        public IQueryable<Doctor> Entities => _repository.Entities.Where(c => !c.DeletedAt.HasValue);

        public async Task<Doctor> AddAsync(Doctor entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Doctor entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsEnabled = false;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            var register = await _repository.GetByIdAsync(id);
            register = register != null && register.DeletedAt.HasValue ? null : register;
            return register;
        }

        public async Task<List<Doctor>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Doctor entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
```

<sub>*src\api\MedicalClinic.Infrastructure\Repositories\Entities\DoctorRepository.cs*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.Infrastructure/Repositories/Entities/DoctorRepository.cs)</sub>

## CQRS (Command Query Responsibility Segregation)
Um outro padrão de arquitetura utilizado foi o CQRS, que consiste em separar as interações com o banco de dados em operações de leitura e escrita, os chamados 'commands' e 'queries'. 

No entanto, o padão CQRS é mais recomendado em APIs robustas e de grande porte, como podemos ver na própria documentação da Microsoft:
> "Nas arquiteturas tradicionais, o mesmo modelo de dados é usado para consultar e atualizar um banco de dados. É simples e funciona bem para operações CRUD básicas. Em aplicativos mais complexos, no entanto, essa abordagem pode se tornar complicada"
> — *[Microsoft Documentation](https://learn.microsoft.com/pt-br/azure/architecture/patterns/cqrs)*

![image](https://github.com/antonioscript/AutomativeRepairAPI/assets/10932478/2ca4dbbd-2887-41b1-af11-09e1ff0c7aa5)

Por mais que o projeto em questão seja uma API de pequeno porte, a escolha em utilizar esse padrão foi simplesmente para experimentar e simular como funcionaria a arquitetura em .NET em relação a grandes solicitações e acessos por parte da API. 

Na aplicação, os commands e queries foram alocados na camada de aplicação, no diretório de features (casos de uso), que são as lógicas de negócios da API. Para operações de escrita os métodos foram organizados em commands e os métodos de leitura em queries:

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/6becffca-9dbc-4447-99cf-8237203af31b)

Todos os métodos, sejam de escrita ou de leitura, devem fazer parte de uma única classe, para evitar um acoplamento desnecessário. Logo abaixo há um exemplo de um método de escrita (command), nesse caso um POST, responsável por criar um novo médico no banco de dados:

```csharp
namespace MedicalClinic.Application.Features.Doctors.Commands
{
    public partial class CreateDoctorCommand : IRequest<Result<int>>
    {
        public int SpecialtyId { get; set; }
        public string Crm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 

        public string Phone { get; set; } 
        public string? Email { get; set; }
        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }

        public bool IsEnabled { get; set; }
    }


    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Result<int>>
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateDoctorCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var registerExists = await _repository.Entities
               .Where(d => d.Crm == request.Crm)
               .AsNoTracking()
               .FirstOrDefaultAsync();

            if (registerExists != null)
            {
                return Result<int>.Fail(string.Format(SharedResource.MESSAGE_DOCTOR_EXISTS, request.Crm));
            }

            var register = _mapper.Map<Doctor>(request);
            await _repository.AddAsync(register);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(register.Id);
        }
    }
}

```
<sub>*src\api\MedicalClinic.Application\Features\Doctors\Command\CreateDcotorCommand.cs*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.Application/Features/Doctors/Command/CreateDcotorCommand.cs)</sub>

<br>
<br>
<br>
E logo abaixo um exemplo de uma consulta (query), que retorna um médico a partir de um ID especificado:

```csharp
namespace MedicalClinic.Application.Features.Doctors.Queries
{
    public class GetDoctorByIdQuery : IRequest<Result<DoctorResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Result<DoctorResponse>>
        {
            private readonly IDoctorRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(IDoctorRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<DoctorResponse>> Handle(GetDoctorByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .Include(d => d.Specialty)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<DoctorResponse>(result);
                return Result<DoctorResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}
```
<sub>*src\api\MedicalClinic.Application\Features\Doctors\Queries\GetDoctorByIdQuery.cs*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.Application/Features/Doctors/Queries/GetDoctorByIdQuery.cs)</sub>


Com a utilização do CQRS o Controller fica muito mais limpo e legível, sem a necessidade de quaquer linha adicional de código, uma vez que a lógica da aplicação não se encontra mais no Controller, que fica apenas responsável por ser uma meio necessário para se chegar até os comandos da aplicação. Com isso também ocultamos da camada de apresentação quais são os repositórios ou métodos responsáveis pelo acesso ao banco de dados, tornando nosso construtor limpo de qualquer refeência de repositório.


``` csharp
namespace MedicalClinic.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var results = await _mediator.Send(new GetAllDoctorQuery());
            return Ok(results);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateDoctorCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

       //...

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, UpdateDoctorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteDoctorCommand { Id = id }));
        }
    }
}
```

<sub>*src\api\MedicalClinic.WebApi\Controllers\v1\DoctorController.cs*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.WebApi/Controllers/v1/DoctorController.cs)</sub>


## Mediator Pattern
No projeto, também foi utilizado um outro padrão de projeto chamado Mediator. Este padrão é utilizado para definir um objeto que encapsula a forma como um conjunto de objetos interage, em vez de os objetos comunicarem-se diretamente uns com os outros, eles se comunicam através do mediador, que sabe como coordenar e gerenciar essas interações.

![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/6246e9a4-48cc-4dcb-8638-3d96aae8f8cf)

Na API, o mediador ajuda a manter a organização e a clareza na comunicação entre os componentes. Em vez de cada parte do sistema ter que conhecer todas as outras, elas só precisavam saber como interagir com o mediador. Isso deixou o código mais limpo, mais fácil de manter e menos suscetível a erros.

Um bom exemplo onde podemos observar melhor essa interação acontecendo, é através dos Controllers:

``` csharp
[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var results = await _mediator.Send(new GetAllDoctorQuery());
        return Ok(results);
    }

    //...
```
<sub>*src\api\MedicalClinic.WebApi\Controllers\v1\DoctorController.cs*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.WebApi/Controllers/v1/DoctorController.cs)</sub>


## Unit of Work
Para a confirmação de uma ação de escrita no banco de dados, foi utilizado o padrão "Unit of Work". Este padrão é amplamente empregado em aplicações modernas, onde seu objetivo é assegurar que todas as alterações sejam realizadas com sucesso ou que nenhuma seja aplicada em caso de falha.

Ele monitora essas operações e assegura que, ao final do processo, todas as alterações sejam confirmadas (commitadas) ou revertidas (roll back) em conjunto.


![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/c3d98875-6fc1-4019-b59f-168c0506d3b7)


</br>Na API esse padrão foi utilizado criando uma interface onde reune os métodos que servirão par confirmar ou reverter as transações.

``` csharp
public interface IUnitOfWork 
{
    public bool HasChanges { get; }

    Task<int> Commit(CancellationToken cancellationToken);

    Task Rollback();
}
```
<sub>*src\api\MedicalClinic.Application\Interfaces\Repositories\IUnitOfWork.cs*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.Application/Interfaces/Repositories/IUnitOfWork.cs)</sub>



E a sua implementação acontece utilizando uma classe que implementa os métodos da interface. 

``` csharp
namespace MedicalClinic.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private bool disposed;

        public bool HasChanges => _dbContext != null ? _dbContext.HasChanges : false;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task Rollback()
        {
            throw new NotImplementedException();
        }
    }
}

```
<sub>*src\api\MedicalClinic.Infrastructure\Repositories\UnitOfWork.cs*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.Infrastructure/Repositories/UnitOfWork.cs)</sub>

O método de 'commit' é chamado na aplicação ao final de cada transação ou operação no código, logo abaixo está o exemplo de uma operação simples de atualização:


``` csharp
//...

public async Task<Result<int>> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
{
    var register = await _repository.GetByIdAsync(command.Id);

    if (register == null)
    {
        return Result<int>.Fail(string.Format(SharedResource.MESSAGE_DOCTOR_NOT_FOUND, command.Id));
    }
    else
    {
        var registerExists = await _repository.Entities
            .Where(d => d.Id != command.Id && d.Crm == command.Crm)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (registerExists != null)
        {
            return Result<int>.Fail(string.Format(SharedResource.MESSAGE_DOCTOR_EXISTS, command.Crm));
        }
        else
        {
            register.SpecialtyId = command.SpecialtyId;
            register.Crm = command.Crm;

            register.FirstName = command.FirstName ?? register.FirstName;
            register.LastName = command.LastName ?? register.LastName;
            register.Phone = command.Phone ?? register.Phone;
            register.Email = command.Email ?? register.Email;
            register.AddressLineOne = command.AddressLineOne ?? register.AddressLineOne;
            register.AddressLineTwo = command.AddressLineTwo ?? register.AddressLineTwo;

            register.IsEnabled = command.IsEnabled;

            await _repository.UpdateAsync(register);
            await _unitOfWork.Commit(cancellationToken); //Comita as alterações no banco
            return Result<int>.Success(register.Id);
        }
    }
    //...
}

```

<sub>*src\api\MedicalClinic.Application\Features\Doctors\Command\UpdateDoctorCommand.cs
*. [Visualize aqui](https://github.com/antonioscript/MedicalClinicAPI/blob/master/src/api/MedicalClinic.Application/Features/Doctors/Command/UpdateDoctorCommand.cs)</sub>



## Segurança








