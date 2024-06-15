# MedicalClinicAPI
MedicalClinicAPI is a RESTful API designed to manage medical clinic operations and patient records. It provides a comprehensive set of endpoints to handle patient information, doctor details, appointment scheduling, medical history, prescriptions, and more
<p align="center">
  <img src="https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/90cb77bb-f55d-455d-acf7-516608ad97dd.png" alt="Medical Clinic">
</p>

## Keep Up With the Latest Updates on This Project
The project is currently under development. You can follow all new features, updates, and implementations by clicking here: </br>
[Project Repository](https://github.com/users/antonioscript/projects/2?pane=info)


## Database Design
![image](https://github.com/antonioscript/MedicalClinicAPI/assets/10932478/f294da84-e682-48c9-aa38-6ab729b05de9)

# Funcionalidades
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
