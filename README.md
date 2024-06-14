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

