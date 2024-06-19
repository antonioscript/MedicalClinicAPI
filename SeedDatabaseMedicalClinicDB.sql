USE [master]
GO
/****** Object:  Database [MedicalClinicDB]    Script Date: 19/06/2024 17:01:36 ******/
CREATE DATABASE [MedicalClinicDB]
GO
ALTER DATABASE [MedicalClinicDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MedicalClinicDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MedicalClinicDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MedicalClinicDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MedicalClinicDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MedicalClinicDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MedicalClinicDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MedicalClinicDB] SET  MULTI_USER 
GO
ALTER DATABASE [MedicalClinicDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MedicalClinicDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MedicalClinicDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MedicalClinicDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MedicalClinicDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MedicalClinicDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MedicalClinicDB', N'ON'
GO
ALTER DATABASE [MedicalClinicDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [MedicalClinicDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MedicalClinicDB]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[DoctorId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SpecialtyId] [int] NOT NULL,
	[Crm] [varchar](20) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](50) NULL,
	[AddressLineOne] [varchar](100) NULL,
	[AddressLineTwo] [varchar](100) NULL,
	[IsEnabled ] [bit] NOT NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DoctorView]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DoctorView] AS
SELECT FirstName, LastName, Email, Crm
FROM Doctors;
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[RequestingDoctorId] [int] NULL,
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[AppointmentDate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Observation] [varchar](200) NULL,
	[IsEnabled ] [bit] NOT NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Availabilities]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Availabilities](
	[AvailabilityId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[DoctorId] [int] NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[IsEnabled ] [bit] NOT NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_Availability] PRIMARY KEY CLUSTERED 
(
	[AvailabilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CanceledAppointment]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CanceledAppointment](
	[CanceledAppointmentId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[AppointmentId] [int] NOT NULL,
	[ReasonCancellation] [varchar](250) NOT NULL,
	[CancellationDate] [datetime] NOT NULL,
 CONSTRAINT [CanceledAppointment_PK] PRIMARY KEY CLUSTERED 
(
	[CanceledAppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentParameter]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentParameter](
	[DocumentParameterId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[LocalizationDocumentInput] [varchar](200) NOT NULL,
	[LocalizationDocumentOutput] [varchar](200) NOT NULL,
	[LocalizationLibreOffice] [varchar](200) NOT NULL,
	[DocumentType] [tinyint] NOT NULL,
 CONSTRAINT [PK_DocumentParameter] PRIMARY KEY CLUSTERED 
(
	[DocumentParameterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[ExamId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
	[Value] [decimal](18, 6) NOT NULL,
	[IsEnabled ] [bit] NOT NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[ExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forwardings]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forwardings](
	[ForwardingId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PrescriptionId] [int] NOT NULL,
	[SpecialtyId] [int] NOT NULL,
	[Observation] [varchar](1000) NULL,
 CONSTRAINT [PK_Forwardings] PRIMARY KEY CLUSTERED 
(
	[ForwardingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insurances]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insurances](
	[InsuranceId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NULL,
	[PercentageTypeOne] [decimal](18, 6) NOT NULL,
	[PercentageTypeTwo] [decimal](18, 6) NOT NULL,
	[PercentageTypeThree] [decimal](18, 6) NOT NULL,
	[IsEnabled ] [bit] NOT NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_Insurance] PRIMARY KEY CLUSTERED 
(
	[InsuranceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medications]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medications](
	[MedicationId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PrescriptionId] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[SubstituteOne] [varchar](100) NULL,
	[SubstituteTwo] [varchar](100) NULL,
	[Instruction] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Medications] PRIMARY KEY CLUSTERED 
(
	[MedicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[InsuranceId] [int] NULL,
	[InsuranceType] [tinyint] NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Document] [varchar](20) NOT NULL,
	[DateOfBirth ] [datetime] NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[PhoneOne] [varchar](20) NOT NULL,
	[PhoneTwo] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[AddressLineOne] [varchar](100) NULL,
	[AddressLineTwo] [varchar](100) NULL,
	[IsEnabled ] [bit] NOT NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescriptions]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescriptions](
	[PrescriptionId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[AppointmentId] [int] NOT NULL,
	[Observation] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_Prescriptions] PRIMARY KEY CLUSTERED 
(
	[PrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Procedures]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procedures](
	[ProcedureId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PatientId] [int] NOT NULL,
	[TechnicianId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[Observation] [varchar](200) NULL,
	[IsEnabled ] [bit] NOT NULL,
	[DeletedAt] [datetime] NULL,
	[ProcedureDate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_Procedures] PRIMARY KEY CLUSTERED 
(
	[ProcedureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshTokens ]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshTokens ](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[UserId ] [nvarchar](max) NOT NULL,
	[Token] [nvarchar](max) NOT NULL,
	[JwtId ] [nvarchar](max) NOT NULL,
	[IsUsed ] [bit] NOT NULL,
	[IsRevoked ] [bit] NOT NULL,
	[AddedDate ] [datetime2](7) NOT NULL,
	[ExpiryDate ] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RefreshTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialties]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialties](
	[SpecialtyId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](60) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[ConsultationValue] [decimal](18, 6) NOT NULL,
	[IsEnabled ] [bit] NOT NULL,
	[DeletedAt] [datetime] NULL,
	[AppointmentDuration] [int] NOT NULL,
 CONSTRAINT [PK_Specialties] PRIMARY KEY CLUSTERED 
(
	[SpecialtyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Technicians]    Script Date: 19/06/2024 17:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Technicians](
	[TechnicianId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[AddressLineOne] [varchar](100) NULL,
	[AddressLineTwo] [varchar](100) NULL,
	[InsuranceType] [tinyint] NULL,
	[IsEnabled ] [bit] NOT NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_Technicians] PRIMARY KEY CLUSTERED 
(
	[TechnicianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentId], [RequestingDoctorId], [PatientId], [DoctorId], [AppointmentDate], [Status], [Observation], [IsEnabled ], [DeletedAt]) VALUES (1013, NULL, 1, 1007, CAST(N'2024-07-29T10:00:00.000' AS DateTime), 3, N'Follow-up consultation', 1, NULL)
INSERT [dbo].[Appointments] ([AppointmentId], [RequestingDoctorId], [PatientId], [DoctorId], [AppointmentDate], [Status], [Observation], [IsEnabled ], [DeletedAt]) VALUES (1014, NULL, 2, 1008, CAST(N'2024-07-30T10:00:00.000' AS DateTime), 0, N'Routine check-up', 1, NULL)
INSERT [dbo].[Appointments] ([AppointmentId], [RequestingDoctorId], [PatientId], [DoctorId], [AppointmentDate], [Status], [Observation], [IsEnabled ], [DeletedAt]) VALUES (1015, NULL, 3, 1009, CAST(N'2024-07-31T11:00:00.000' AS DateTime), 3, N'Physical examination', 1, NULL)
INSERT [dbo].[Appointments] ([AppointmentId], [RequestingDoctorId], [PatientId], [DoctorId], [AppointmentDate], [Status], [Observation], [IsEnabled ], [DeletedAt]) VALUES (1016, NULL, 4, 1011, CAST(N'2024-08-01T14:00:00.000' AS DateTime), 0, N'Blood pressure check', 1, NULL)
INSERT [dbo].[Appointments] ([AppointmentId], [RequestingDoctorId], [PatientId], [DoctorId], [AppointmentDate], [Status], [Observation], [IsEnabled ], [DeletedAt]) VALUES (1018, NULL, 6, 1012, CAST(N'2024-08-02T15:00:00.000' AS DateTime), 3, N'Consultation for allergies', 1, NULL)
INSERT [dbo].[Appointments] ([AppointmentId], [RequestingDoctorId], [PatientId], [DoctorId], [AppointmentDate], [Status], [Observation], [IsEnabled ], [DeletedAt]) VALUES (1019, NULL, 8, 1013, CAST(N'2024-08-03T15:00:00.000' AS DateTime), 0, N'Initial consultation', 1, NULL)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'0283b045-6326-4e5a-9ad4-039b7f22843d', 0, N'86fb9007-38b8-42fc-aeb8-e781965b5916', N'joao@gmail.com', 0, 1, NULL, N'JOAO@GMAIL.COM', N'JOAO', N'AQAAAAEAACcQAAAAEDCPUy/wl05aelfXdNHxky9QI8lQhlc6jZ9F0cSDCk+FyP0GEFXDDVxEDvqbv46A+g==', NULL, 0, N'KA7SV7G2FPG4EU2RGAX3Q5XMQ6KMPE4V', 0, N'joao')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'72a94ffb-2b58-4e64-b661-5e05ce4571b8', 0, N'6c7dfaa8-421e-4acf-99ee-b8e5f0b245fa', N'user@gmail.com', 0, 1, NULL, N'USER@GMAIL.COM', N'USERTEST', N'AQAAAAEAACcQAAAAEI/gOZ1VI3h4jbu9utwEbdCAkfaRWRvHnHKIg+tD5Fd7mKJp1ozq4aR+tgB9+cJtVw==', NULL, 0, N'XKIYKCUF3QU3OUWHL3VU3QYSMSLDHH4D', 0, N'usertest')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'a3090270-36bb-4378-8da1-6657bc7f0bbe', 0, N'8b91268d-b300-4e0e-bd7c-6a20eb766bde', N'jhon@email.com', 0, 1, NULL, N'JHON@EMAIL.COM', N'JHON', N'AQAAAAEAACcQAAAAEPTOizn3Ds69B+ojFtTSxw/hXisrpuSDBRZXiQAMaGJu3kqz9fpCTynbCH1PFwcAWA==', NULL, 0, N'2ZEFCR33SIOK3W5ZMWA3PDNJVAJ654UK', 0, N'Jhon')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'cf3358f2-7d25-4a39-a57b-a186d1cb6833', 0, N'ad8cf9ab-e463-41e9-9cb5-93cc2cdbfe90', N'user1@gmail.com', 0, 1, NULL, N'USER1@GMAIL.COM', N'USERTEST1', N'AQAAAAEAACcQAAAAEFBmR8UxCdvzt9yzswDINrJ5mZGdLCXU83MWDvI4I1V5LelsINXhmWGChdpcNqTJsA==', NULL, 0, N'KKGKXD6C7HOEKPQMUZ3HCB5YN3RAWYIA', 0, N'usertest1')
GO
SET IDENTITY_INSERT [dbo].[Availabilities] ON 

INSERT [dbo].[Availabilities] ([AvailabilityId], [DoctorId], [DayOfWeek], [StartTime], [EndTime], [IsEnabled ], [DeletedAt]) VALUES (1001, 1007, 1, CAST(N'08:00:00' AS Time), CAST(N'12:00:00' AS Time), 1, NULL)
INSERT [dbo].[Availabilities] ([AvailabilityId], [DoctorId], [DayOfWeek], [StartTime], [EndTime], [IsEnabled ], [DeletedAt]) VALUES (1002, 1008, 2, CAST(N'09:00:00' AS Time), CAST(N'13:00:00' AS Time), 1, NULL)
INSERT [dbo].[Availabilities] ([AvailabilityId], [DoctorId], [DayOfWeek], [StartTime], [EndTime], [IsEnabled ], [DeletedAt]) VALUES (1003, 1009, 3, CAST(N'10:00:00' AS Time), CAST(N'14:00:00' AS Time), 1, NULL)
INSERT [dbo].[Availabilities] ([AvailabilityId], [DoctorId], [DayOfWeek], [StartTime], [EndTime], [IsEnabled ], [DeletedAt]) VALUES (1004, 1011, 4, CAST(N'11:00:00' AS Time), CAST(N'15:00:00' AS Time), 1, NULL)
INSERT [dbo].[Availabilities] ([AvailabilityId], [DoctorId], [DayOfWeek], [StartTime], [EndTime], [IsEnabled ], [DeletedAt]) VALUES (1005, 1012, 5, CAST(N'12:00:00' AS Time), CAST(N'16:00:00' AS Time), 1, NULL)
INSERT [dbo].[Availabilities] ([AvailabilityId], [DoctorId], [DayOfWeek], [StartTime], [EndTime], [IsEnabled ], [DeletedAt]) VALUES (1006, 1013, 6, CAST(N'13:00:00' AS Time), CAST(N'17:00:00' AS Time), 1, NULL)
SET IDENTITY_INSERT [dbo].[Availabilities] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([DoctorId], [SpecialtyId], [Crm], [FirstName], [LastName], [Phone], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1007, 1, N'123456', N'Henry', N'Adams', N'+1 (123) 456-7890', N'henry.adams@example.com', N'101 First Street', N'Apt 1A', 1, NULL)
INSERT [dbo].[Doctors] ([DoctorId], [SpecialtyId], [Crm], [FirstName], [LastName], [Phone], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1008, 2, N'234567', N'Ella', N'Baker', N'+1 (234) 567-8901', N'ella.baker@example.com', N'202 Second Avenue', NULL, 1, NULL)
INSERT [dbo].[Doctors] ([DoctorId], [SpecialtyId], [Crm], [FirstName], [LastName], [Phone], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1009, 3, N'345678', N'Lucas', N'Clark', N'+1 (345) 678-9012', N'lucas.clark@example.com', N'303 Third Boulevard', N'Suite 3C', 1, NULL)
INSERT [dbo].[Doctors] ([DoctorId], [SpecialtyId], [Crm], [FirstName], [LastName], [Phone], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1010, 4, N'456789', N'Mia', N'Davis', N'+1 (456) 789-0123', N'mia.davis@example.com', N'404 Fourth Lane', N'House 4', 0, NULL)
INSERT [dbo].[Doctors] ([DoctorId], [SpecialtyId], [Crm], [FirstName], [LastName], [Phone], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1011, 5, N'567890', N'Oliver', N'Evans', N'+1 (567) 890-1234', N'oliver.evans@example.com', N'505 Fifth Road', N'Unit 5B', 1, NULL)
INSERT [dbo].[Doctors] ([DoctorId], [SpecialtyId], [Crm], [FirstName], [LastName], [Phone], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1012, 1, N'678901', N'Emma', N'Wilson', N'+1 (678) 901-2345', N'emma.wilson@example.com', N'606 Sixth Street', N'Apt 6A', 1, NULL)
INSERT [dbo].[Doctors] ([DoctorId], [SpecialtyId], [Crm], [FirstName], [LastName], [Phone], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1013, 2, N'789012', N'James', N'Moore', N'+1 (789) 012-3456', N'james.moore@example.com', N'707 Seventh Avenue', N'Suite 7B', 1, NULL)
INSERT [dbo].[Doctors] ([DoctorId], [SpecialtyId], [Crm], [FirstName], [LastName], [Phone], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1014, 4, N'901234', N'Charlotte', N'Garcia', N'+1 (901) 234-5678', N'charlotte.garcia@example.com', N'909 Ninth Lane', N'House 9', 1, NULL)
INSERT [dbo].[Doctors] ([DoctorId], [SpecialtyId], [Crm], [FirstName], [LastName], [Phone], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1015, 1, N'012345', N'Mason', N'Thomas', N'+1 (012) 345-6789', N'mason.thomas@example.com', N'1010 Tenth Road', NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Doctors] OFF
GO
SET IDENTITY_INSERT [dbo].[Exams] ON 

INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (1, N'Blood Test', N'Basic blood analysis', CAST(80.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (2, N'X-ray', N'Radiographic imaging', CAST(150.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (3, N'MRI', N'Magnetic resonance imaging', CAST(300.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (4, N'Ultrasound', N'Diagnostic ultrasound', CAST(200.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (5, N'Electrocardiogram (ECG)', N'Medical test to measure electrical activity of the heart over a period of time', CAST(100.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (6, N'CT Scan', N'Computed tomography imaging', CAST(350.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (7, N'Mammography', N'Breast imaging for cancer screening', CAST(120.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (8, N'Thyroid Function Test', N'Test to evaluate thyroid function', CAST(70.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (9, N'Colonoscopy', N'Examination of the colon using a camera', CAST(250.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Exams] ([ExamId], [Name], [Description], [Value], [IsEnabled ], [DeletedAt]) VALUES (10, N'Urine Analysis', N'Basic urine analysis to detect various disorders', CAST(50.000000 AS Decimal(18, 6)), 1, NULL)
SET IDENTITY_INSERT [dbo].[Exams] OFF
GO
SET IDENTITY_INSERT [dbo].[Forwardings] ON 

INSERT [dbo].[Forwardings] ([ForwardingId], [PrescriptionId], [SpecialtyId], [Observation]) VALUES (6, 6, 1, N'Patient needs referral to a neurologist for further evaluation of headaches.')
INSERT [dbo].[Forwardings] ([ForwardingId], [PrescriptionId], [SpecialtyId], [Observation]) VALUES (7, 6, 3, N'Consider referral to a psychiatrist for assessment of fatigue and mood.')
INSERT [dbo].[Forwardings] ([ForwardingId], [PrescriptionId], [SpecialtyId], [Observation]) VALUES (8, 7, 2, N'Refer patient to orthopedics for evaluation and management of lower back pain.')
INSERT [dbo].[Forwardings] ([ForwardingId], [PrescriptionId], [SpecialtyId], [Observation]) VALUES (9, 8, 4, N'Consider referral to pulmonology for further evaluation of chronic cough.')
SET IDENTITY_INSERT [dbo].[Forwardings] OFF
GO
SET IDENTITY_INSERT [dbo].[Insurances] ON 

INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (1, N'Basic Plan', N'Provides basic healthcare coverage.', CAST(0.150000 AS Decimal(18, 6)), CAST(0.250000 AS Decimal(18, 6)), CAST(0.100000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (2, N'Premium Plan', N'Comprehensive healthcare coverage with additional benefits.', CAST(0.200000 AS Decimal(18, 6)), CAST(0.350000 AS Decimal(18, 6)), CAST(0.150000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (3, N'Family Plan', N'Covers healthcare for the whole family at a discounted rate.', CAST(0.180000 AS Decimal(18, 6)), CAST(0.300000 AS Decimal(18, 6)), CAST(0.120000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (4, N'Senior Plan', N'Tailored for senior citizens with specialized care options.', CAST(0.120000 AS Decimal(18, 6)), CAST(0.200000 AS Decimal(18, 6)), CAST(0.080000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (5, N'HealthGuard Insurance', N'A reliable health insurance provider offering a variety of plans for individuals and families.', CAST(70.000000 AS Decimal(18, 6)), CAST(50.000000 AS Decimal(18, 6)), CAST(30.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (6, N'WellCare Health Services', N'Premium health insurance solutions with comprehensive coverage and exceptional customer service.', CAST(90.000000 AS Decimal(18, 6)), CAST(80.000000 AS Decimal(18, 6)), CAST(70.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (7, N'FamilyFirst Health', N'Dedicated to providing affordable and comprehensive health insurance plans for families.', CAST(85.000000 AS Decimal(18, 6)), CAST(75.000000 AS Decimal(18, 6)), CAST(60.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (8, N'LifeSecure Insurance', N'Offering comprehensive health insurance plans with a focus on preventive care and wellness.', CAST(75.000000 AS Decimal(18, 6)), CAST(65.000000 AS Decimal(18, 6)), CAST(55.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (9, N'TotalHealth Coverage', N'Providing extensive health insurance plans with a wide network of healthcare providers.', CAST(80.000000 AS Decimal(18, 6)), CAST(70.000000 AS Decimal(18, 6)), CAST(60.000000 AS Decimal(18, 6)), 1, NULL)
INSERT [dbo].[Insurances] ([InsuranceId], [Name], [Description], [PercentageTypeOne], [PercentageTypeTwo], [PercentageTypeThree], [IsEnabled ], [DeletedAt]) VALUES (10, N'PrimeCare Health Insurance', N'Leading provider of health insurance plans tailored to meet the needs of individuals and businesses.', CAST(85.000000 AS Decimal(18, 6)), CAST(75.000000 AS Decimal(18, 6)), CAST(65.000000 AS Decimal(18, 6)), 1, NULL)
SET IDENTITY_INSERT [dbo].[Insurances] OFF
GO
SET IDENTITY_INSERT [dbo].[Medications] ON 

INSERT [dbo].[Medications] ([MedicationId], [PrescriptionId], [Name], [SubstituteOne], [SubstituteTwo], [Instruction]) VALUES (6, 6, N'Paracetamol', N'Ibuprofen', N'Aspirin', N'Take one tablet every 6 hours as needed for pain.')
INSERT [dbo].[Medications] ([MedicationId], [PrescriptionId], [Name], [SubstituteOne], [SubstituteTwo], [Instruction]) VALUES (7, 6, N'Loratadine', N'Cetirizine', N'Diphenhydramine', N'Take one tablet daily for allergies.')
INSERT [dbo].[Medications] ([MedicationId], [PrescriptionId], [Name], [SubstituteOne], [SubstituteTwo], [Instruction]) VALUES (8, 7, N'Ibuprofen', N'Naproxen', N'Acetaminophen', N'Take one tablet every 8 hours as needed for pain relief.')
INSERT [dbo].[Medications] ([MedicationId], [PrescriptionId], [Name], [SubstituteOne], [SubstituteTwo], [Instruction]) VALUES (9, 8, N'Azithromycin', N'Amoxicillin', N'Doxycycline', N'Take one tablet daily for 5 days.')
SET IDENTITY_INSERT [dbo].[Medications] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (1, 1, 1, N'John', N'Doe', N'123456789', CAST(N'1990-05-15T00:00:00.000' AS DateTime), 1, N'+1 (123) 456-7890', N'+1 (987) 654-3210', N'john.doe@email.com', N'123 Main Street', N'Apt 4B', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (2, 2, 2, N'Jane', N'Smith', N'987654321', CAST(N'1985-08-25T00:00:00.000' AS DateTime), 2, N'+1 (555) 123-4567', NULL, N'jane.smith@email.com', N'456 Oak Avenue', N'UK', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (3, 3, 1, N'Michael', N'Johnson', N'456789123', CAST(N'1995-02-10T00:00:00.000' AS DateTime), 1, N'+1 (777) 888-9999', N'+1 (444) 555-6666', N'michael.johnson@email.com', N'789 Maple Lane', N'Suite 202', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (4, 4, 2, N'Sophia', N'Williams', N'789123456', CAST(N'1980-11-05T00:00:00.000' AS DateTime), 2, N'+1 (222) 333-4444', NULL, N'sophia.williams@email.com', N'456 Pine Road', NULL, 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (6, 5, 1, N'John', N'Wall', N'128456789', CAST(N'1985-02-15T00:00:00.000' AS DateTime), 0, N'+1234567890', N'+0987654321', N'john.doe@example.com', N'123 Main St', N'Apt 4B', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (8, 6, 2, N'Jane', N'Williamns', N'287654321', CAST(N'1990-07-22T00:00:00.000' AS DateTime), 0, N'+2345678901', N'+1098765432', N'jane.smith@example.com', N'456 Elm St', N'Suite 5A', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (9, 7, 3, N'Alice', N'Johnson', N'1122334455', CAST(N'1988-03-10T00:00:00.000' AS DateTime), 0, N'+3456789012', N'+2109876543', N'alice.johnson@example.com', N'789 Oak St', N'Floor 3', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (10, 8, 1, N'Robert', N'Brown', N'5566778899', CAST(N'1975-11-30T00:00:00.000' AS DateTime), 0, N'+4567890123', N'+3210987654', N'robert.brown@example.com', N'101 Maple St', N'Unit 12', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (11, 9, 2, N'Emily', N'Davis', N'6677889900', CAST(N'1995-06-14T00:00:00.000' AS DateTime), 0, N'+5678901234', N'+4321098765', N'emily.davis@example.com', N'202 Pine St', N'Apt 7C', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (12, 10, 3, N'Michael', N'Wilson', N'7788990011', CAST(N'1982-09-25T00:00:00.000' AS DateTime), 0, N'+6789012345', N'+5432109876', N'michael.wilson@example.com', N'303 Birch St', N'House 9', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (13, 1, 1, N'Liam', N'Martinez', N'3344556677', CAST(N'1992-01-15T00:00:00.000' AS DateTime), 0, N'+1 (888) 999-0000', N'+1 (999) 888-0000', N'liam.martinez@example.com', N'909 Walnut Street', N'Apt 5D', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (14, 2, 2, N'Noah', N'Taylor', N'4455667788', CAST(N'1987-03-22T00:00:00.000' AS DateTime), 0, N'+1 (777) 666-5555', NULL, N'noah.taylor@example.com', N'101 Pine Avenue', NULL, 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (16, 8, 3, N'Ava', N'Clark', N'1566778899', CAST(N'1990-09-10T00:00:00.000' AS DateTime), 0, N'+1 (666) 555-4444', N'+1 (555) 666-7777', N'ava.clark@example.com', N'202 Maple Avenue', N'Suite 7B', 1, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (18, 10, 1, N'Mia', N'Garcia', N'6673889900', CAST(N'1995-07-07T00:00:00.000' AS DateTime), 0, N'+1 (444) 333-2222', N'+1 (333) 444-5555', N'mia.garcia@example.com', N'303 Birch Road', N'House 8', 0, NULL)
INSERT [dbo].[Patients] ([PatientId], [InsuranceId], [InsuranceType], [FirstName], [LastName], [Document], [DateOfBirth ], [Gender], [PhoneOne], [PhoneTwo], [Email], [AddressLineOne], [AddressLineTwo], [IsEnabled ], [DeletedAt]) VALUES (20, 10, 2, N'Ethan', N'Rodriguez', N'7788920011', CAST(N'1984-12-12T00:00:00.000' AS DateTime), 0, N'+1 (222) 111-0000', NULL, N'ethan.rodriguez@example.com', N'404 Elm Street', N'Apt 2A', 1, NULL)
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
SET IDENTITY_INSERT [dbo].[Prescriptions] ON 

INSERT [dbo].[Prescriptions] ([PrescriptionId], [AppointmentId], [Observation]) VALUES (6, 1013, N'Patient complains of mild headaches and fatigue.')
INSERT [dbo].[Prescriptions] ([PrescriptionId], [AppointmentId], [Observation]) VALUES (7, 1015, N'Patient presents with acute lower back pain after lifting heavy objects.')
INSERT [dbo].[Prescriptions] ([PrescriptionId], [AppointmentId], [Observation]) VALUES (8, 1018, N'Patient reports persistent cough with yellowish sputum for the past week.')
SET IDENTITY_INSERT [dbo].[Prescriptions] OFF
GO
SET IDENTITY_INSERT [dbo].[Procedures] ON 

INSERT [dbo].[Procedures] ([ProcedureId], [PatientId], [TechnicianId], [ExamId], [Observation], [IsEnabled ], [DeletedAt], [ProcedureDate], [Status]) VALUES (1, 1, 1, 1, N'Routine blood test', 1, NULL, CAST(N'2024-01-20T17:37:12.357' AS DateTime), 0)
INSERT [dbo].[Procedures] ([ProcedureId], [PatientId], [TechnicianId], [ExamId], [Observation], [IsEnabled ], [DeletedAt], [ProcedureDate], [Status]) VALUES (2, 2, 2, 2, N'Chest X-ray', 1, NULL, CAST(N'2024-01-21T17:37:12.357' AS DateTime), 0)
INSERT [dbo].[Procedures] ([ProcedureId], [PatientId], [TechnicianId], [ExamId], [Observation], [IsEnabled ], [DeletedAt], [ProcedureDate], [Status]) VALUES (3, 3, 3, 3, N'MRI Scan', 1, NULL, CAST(N'2024-01-22T17:37:12.357' AS DateTime), 0)
INSERT [dbo].[Procedures] ([ProcedureId], [PatientId], [TechnicianId], [ExamId], [Observation], [IsEnabled ], [DeletedAt], [ProcedureDate], [Status]) VALUES (4, 4, 4, 4, N'Abdominal Ultrasound', 1, NULL, CAST(N'2024-01-23T17:37:12.357' AS DateTime), 0)
INSERT [dbo].[Procedures] ([ProcedureId], [PatientId], [TechnicianId], [ExamId], [Observation], [IsEnabled ], [DeletedAt], [ProcedureDate], [Status]) VALUES (5, 1, 1, 1, N'Observation Test', 1, NULL, CAST(N'2024-01-20T20:50:40.070' AS DateTime), 0)
INSERT [dbo].[Procedures] ([ProcedureId], [PatientId], [TechnicianId], [ExamId], [Observation], [IsEnabled ], [DeletedAt], [ProcedureDate], [Status]) VALUES (6, 1, 1, 1, N'Teste', 1, NULL, CAST(N'2024-01-25T02:13:06.063' AS DateTime), 0)
INSERT [dbo].[Procedures] ([ProcedureId], [PatientId], [TechnicianId], [ExamId], [Observation], [IsEnabled ], [DeletedAt], [ProcedureDate], [Status]) VALUES (7, 1, 1, 1, N'Teste', 1, NULL, CAST(N'2024-01-25T02:14:06.063' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Procedures] OFF
GO
SET IDENTITY_INSERT [dbo].[RefreshTokens ] ON 

INSERT [dbo].[RefreshTokens ] ([Id], [UserId ], [Token], [JwtId ], [IsUsed ], [IsRevoked ], [AddedDate ], [ExpiryDate ]) VALUES (1, N'0283b045-6326-4e5a-9ad4-039b7f22843d', N'RRzpOqUf4vBLzxm8fakWodY', N'092a5fa9-a372-4b0f-bf04-7fffe012c2f6', 0, 0, CAST(N'2024-06-18T21:08:14.8827051' AS DateTime2), CAST(N'2024-12-18T21:08:14.8827055' AS DateTime2))
INSERT [dbo].[RefreshTokens ] ([Id], [UserId ], [Token], [JwtId ], [IsUsed ], [IsRevoked ], [AddedDate ], [ExpiryDate ]) VALUES (2, N'0283b045-6326-4e5a-9ad4-039b7f22843d', N'6X2XbgJEE8FTuehTG54xywA', N'ab073565-3656-4fa5-806e-b9b39350310c', 0, 0, CAST(N'2024-06-18T21:08:50.0432758' AS DateTime2), CAST(N'2024-12-18T21:08:50.0432759' AS DateTime2))
INSERT [dbo].[RefreshTokens ] ([Id], [UserId ], [Token], [JwtId ], [IsUsed ], [IsRevoked ], [AddedDate ], [ExpiryDate ]) VALUES (3, N'0283b045-6326-4e5a-9ad4-039b7f22843d', N'7f7ksOJX5OdnVWLpeCY3fHD', N'ca056284-4f18-4350-92b6-ef2cc204c189', 0, 0, CAST(N'2024-06-18T21:08:59.9962864' AS DateTime2), CAST(N'2024-12-18T21:08:59.9962865' AS DateTime2))
INSERT [dbo].[RefreshTokens ] ([Id], [UserId ], [Token], [JwtId ], [IsUsed ], [IsRevoked ], [AddedDate ], [ExpiryDate ]) VALUES (4, N'a3090270-36bb-4378-8da1-6657bc7f0bbe', N'Sfr0jMAgyXkMryyEXBImt0y', N'01984362-7180-4333-8093-2c7469f0797d', 0, 0, CAST(N'2024-06-18T21:09:41.0708774' AS DateTime2), CAST(N'2024-12-18T21:09:41.0708775' AS DateTime2))
INSERT [dbo].[RefreshTokens ] ([Id], [UserId ], [Token], [JwtId ], [IsUsed ], [IsRevoked ], [AddedDate ], [ExpiryDate ]) VALUES (5, N'a3090270-36bb-4378-8da1-6657bc7f0bbe', N'L7UoW966OiTXKhwLF5SaWAh', N'e415697d-4d14-4c65-8172-79a2161d2ffc', 0, 0, CAST(N'2024-06-18T21:29:46.6129483' AS DateTime2), CAST(N'2024-12-18T21:29:46.6129483' AS DateTime2))
INSERT [dbo].[RefreshTokens ] ([Id], [UserId ], [Token], [JwtId ], [IsUsed ], [IsRevoked ], [AddedDate ], [ExpiryDate ]) VALUES (6, N'a3090270-36bb-4378-8da1-6657bc7f0bbe', N'nTJaYFkbeuN12KI9iOaclrK', N'b5169c94-afc5-4ebb-b90c-a43e3a4992e1', 0, 0, CAST(N'2024-06-18T21:30:16.7721459' AS DateTime2), CAST(N'2024-12-18T21:30:16.7721459' AS DateTime2))
SET IDENTITY_INSERT [dbo].[RefreshTokens ] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialties] ON 

INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description], [ConsultationValue], [IsEnabled ], [DeletedAt], [AppointmentDuration]) VALUES (1, N'Cardiology', N'Deals with disorders of the heart and blood vessels.', CAST(250.000000 AS Decimal(18, 6)), 1, NULL, 0)
INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description], [ConsultationValue], [IsEnabled ], [DeletedAt], [AppointmentDuration]) VALUES (2, N'Pediatrics', N'Focuses on medical care for infants, children, and adolescents.', CAST(200.000000 AS Decimal(18, 6)), 1, NULL, 0)
INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description], [ConsultationValue], [IsEnabled ], [DeletedAt], [AppointmentDuration]) VALUES (3, N'Dermatology', N'Specializes in the treatment of skin, hair, and nail conditions.', CAST(180.000000 AS Decimal(18, 6)), 1, NULL, 0)
INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description], [ConsultationValue], [IsEnabled ], [DeletedAt], [AppointmentDuration]) VALUES (4, N'Orthopedics', N'Deals with the musculoskeletal system and related injuries.', CAST(300.000000 AS Decimal(18, 6)), 1, NULL, 0)
INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description], [ConsultationValue], [IsEnabled ], [DeletedAt], [AppointmentDuration]) VALUES (5, N'Nutrology', N' specialty that studies the nutrients in food and their impact on the body.', CAST(180.000000 AS Decimal(18, 6)), 1, NULL, 60)
INSERT [dbo].[Specialties] ([SpecialtyId], [Name], [Description], [ConsultationValue], [IsEnabled ], [DeletedAt], [AppointmentDuration]) VALUES (6, N'Oftalmologia', N'Tratamento de doenças relacionadas ao olho, à refração e seus anexos.', CAST(150.000000 AS Decimal(18, 6)), 1, NULL, 40)
SET IDENTITY_INSERT [dbo].[Specialties] OFF
GO
SET IDENTITY_INSERT [dbo].[Technicians] ON 

INSERT [dbo].[Technicians] ([TechnicianId], [FirstName], [LastName], [Email], [Phone], [AddressLineOne], [AddressLineTwo], [InsuranceType], [IsEnabled ], [DeletedAt]) VALUES (1, N'Robert', N'Johnson', N'robert.johnson@example.com', N'+1 (123) 456-7890', N'123 Main Street', N'Apt 4B', 1, 1, NULL)
INSERT [dbo].[Technicians] ([TechnicianId], [FirstName], [LastName], [Email], [Phone], [AddressLineOne], [AddressLineTwo], [InsuranceType], [IsEnabled ], [DeletedAt]) VALUES (2, N'Olivia', N'Smith', N'olivia.smith@example.com', N'+1 (555) 123-4567', N'456 Oak Avenue', NULL, 2, 1, NULL)
INSERT [dbo].[Technicians] ([TechnicianId], [FirstName], [LastName], [Email], [Phone], [AddressLineOne], [AddressLineTwo], [InsuranceType], [IsEnabled ], [DeletedAt]) VALUES (3, N'William', N'Doe', N'william.doe@example.com', N'+1 (777) 888-9999', N'789 Maple Lane', N'Suite 202', 1, 1, NULL)
INSERT [dbo].[Technicians] ([TechnicianId], [FirstName], [LastName], [Email], [Phone], [AddressLineOne], [AddressLineTwo], [InsuranceType], [IsEnabled ], [DeletedAt]) VALUES (4, N'Sophie', N'Williams', N'sophie.williams@example.com', N'+1 (222) 333-4444', N'456 Pine Road', NULL, 2, 1, NULL)
INSERT [dbo].[Technicians] ([TechnicianId], [FirstName], [LastName], [Email], [Phone], [AddressLineOne], [AddressLineTwo], [InsuranceType], [IsEnabled ], [DeletedAt]) VALUES (5, N'Alice', N'Brown', N'alice.brown@example.com', N'+1 (333) 555-6666', N'101 Birch Street', N'Apt 3A', 1, 1, NULL)
INSERT [dbo].[Technicians] ([TechnicianId], [FirstName], [LastName], [Email], [Phone], [AddressLineOne], [AddressLineTwo], [InsuranceType], [IsEnabled ], [DeletedAt]) VALUES (6, N'James', N'Davis', N'james.davis@example.com', N'+1 (444) 777-8888', N'202 Cedar Lane', NULL, 2, 1, NULL)
INSERT [dbo].[Technicians] ([TechnicianId], [FirstName], [LastName], [Email], [Phone], [AddressLineOne], [AddressLineTwo], [InsuranceType], [IsEnabled ], [DeletedAt]) VALUES (7, N'Emma', N'Miller', N'emma.miller@example.com', N'+1 (555) 999-0000', N'303 Elm Avenue', N'Suite 100', 3, 1, NULL)
INSERT [dbo].[Technicians] ([TechnicianId], [FirstName], [LastName], [Email], [Phone], [AddressLineOne], [AddressLineTwo], [InsuranceType], [IsEnabled ], [DeletedAt]) VALUES (8, N'Liam', N'Wilson', N'liam.wilson@example.com', N'+1 (666) 111-2222', N'404 Spruce Road', N'Apt 1B', 1, 0, NULL)
SET IDENTITY_INSERT [dbo].[Technicians] OFF
GO
/****** Object:  Index [IX_Appointments_DoctorId]    Script Date: 19/06/2024 17:01:36 ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_DoctorId] ON [dbo].[Appointments]
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointments_Patientid]    Script Date: 19/06/2024 17:01:36 ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_Patientid] ON [dbo].[Appointments]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Availability_DoctorId]    Script Date: 19/06/2024 17:01:36 ******/
CREATE NONCLUSTERED INDEX [IX_Availability_DoctorId] ON [dbo].[Availabilities]
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_CanceledAppointment_AppointmentId]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[CanceledAppointment] ADD  CONSTRAINT [UK_CanceledAppointment_AppointmentId] UNIQUE NONCLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Doctor_Crm_DeletedAt]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[Doctors] ADD  CONSTRAINT [UK_Doctor_Crm_DeletedAt] UNIQUE NONCLUSTERED 
(
	[Crm] ASC,
	[DeletedAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_DocumentParameter]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[DocumentParameter] ADD  CONSTRAINT [UK_DocumentParameter] UNIQUE NONCLUSTERED 
(
	[LocalizationDocumentInput] ASC,
	[LocalizationDocumentOutput] ASC,
	[LocalizationLibreOffice] ASC,
	[DocumentType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Exam_Name_DeletedAt]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[Exams] ADD  CONSTRAINT [UK_Exam_Name_DeletedAt] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[DeletedAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Insurance_Name_DeletedAt]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[Insurances] ADD  CONSTRAINT [UK_Insurance_Name_DeletedAt] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[DeletedAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Patient_Document_DeletedAt]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[Patients] ADD  CONSTRAINT [UK_Patient_Document_DeletedAt] UNIQUE NONCLUSTERED 
(
	[Document] ASC,
	[DeletedAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_Prescription_AppointmentId]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[Prescriptions] ADD  CONSTRAINT [UK_Prescription_AppointmentId] UNIQUE NONCLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_Procedures_ProcedureDate]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[Procedures] ADD  CONSTRAINT [UK_Procedures_ProcedureDate] UNIQUE NONCLUSTERED 
(
	[ProcedureDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Procedures_ExamId]    Script Date: 19/06/2024 17:01:36 ******/
CREATE NONCLUSTERED INDEX [IX_Procedures_ExamId] ON [dbo].[Procedures]
(
	[ExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Procedures_PatientId]    Script Date: 19/06/2024 17:01:36 ******/
CREATE NONCLUSTERED INDEX [IX_Procedures_PatientId] ON [dbo].[Procedures]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Procedures_TechnicianId]    Script Date: 19/06/2024 17:01:36 ******/
CREATE NONCLUSTERED INDEX [IX_Procedures_TechnicianId] ON [dbo].[Procedures]
(
	[TechnicianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Speciality_Name_DeletedAt]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[Specialties] ADD  CONSTRAINT [UK_Speciality_Name_DeletedAt] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[DeletedAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Technicians_FirstName_LastName]    Script Date: 19/06/2024 17:01:36 ******/
ALTER TABLE [dbo].[Technicians] ADD  CONSTRAINT [UK_Technicians_FirstName_LastName] UNIQUE NONCLUSTERED 
(
	[FirstName] ASC,
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Procedures] ADD  DEFAULT (getdate()) FOR [ProcedureDate]
GO
ALTER TABLE [dbo].[Procedures] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Specialties] ADD  DEFAULT ((0)) FOR [AppointmentDuration]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Doctors] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Doctors]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Patients]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Requesting_Doctor] FOREIGN KEY([RequestingDoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Requesting_Doctor]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Availabilities]  WITH CHECK ADD  CONSTRAINT [FK_Availability_Doctors] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
GO
ALTER TABLE [dbo].[Availabilities] CHECK CONSTRAINT [FK_Availability_Doctors]
GO
ALTER TABLE [dbo].[CanceledAppointment]  WITH CHECK ADD  CONSTRAINT [FK_CanceledAppointment_Appointments] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointments] ([AppointmentId])
GO
ALTER TABLE [dbo].[CanceledAppointment] CHECK CONSTRAINT [FK_CanceledAppointment_Appointments]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_Doctors_Specialties] FOREIGN KEY([SpecialtyId])
REFERENCES [dbo].[Specialties] ([SpecialtyId])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_Specialties]
GO
ALTER TABLE [dbo].[Forwardings]  WITH CHECK ADD  CONSTRAINT [FK_Forwarding_Prescriptions] FOREIGN KEY([PrescriptionId])
REFERENCES [dbo].[Prescriptions] ([PrescriptionId])
GO
ALTER TABLE [dbo].[Forwardings] CHECK CONSTRAINT [FK_Forwarding_Prescriptions]
GO
ALTER TABLE [dbo].[Forwardings]  WITH CHECK ADD  CONSTRAINT [FK_Forwarding_Specialties] FOREIGN KEY([SpecialtyId])
REFERENCES [dbo].[Specialties] ([SpecialtyId])
GO
ALTER TABLE [dbo].[Forwardings] CHECK CONSTRAINT [FK_Forwarding_Specialties]
GO
ALTER TABLE [dbo].[Medications]  WITH CHECK ADD  CONSTRAINT [FK_Medication_Prescriptions] FOREIGN KEY([PrescriptionId])
REFERENCES [dbo].[Prescriptions] ([PrescriptionId])
GO
ALTER TABLE [dbo].[Medications] CHECK CONSTRAINT [FK_Medication_Prescriptions]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Insurance] FOREIGN KEY([InsuranceId])
REFERENCES [dbo].[Insurances] ([InsuranceId])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Insurance]
GO
ALTER TABLE [dbo].[Prescriptions]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_Appointments] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointments] ([AppointmentId])
GO
ALTER TABLE [dbo].[Prescriptions] CHECK CONSTRAINT [FK_Prescription_Appointments]
GO
ALTER TABLE [dbo].[Procedures]  WITH CHECK ADD  CONSTRAINT [FK_Procedures_Exams] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exams] ([ExamId])
GO
ALTER TABLE [dbo].[Procedures] CHECK CONSTRAINT [FK_Procedures_Exams]
GO
ALTER TABLE [dbo].[Procedures]  WITH CHECK ADD  CONSTRAINT [FK_Procedures_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
GO
ALTER TABLE [dbo].[Procedures] CHECK CONSTRAINT [FK_Procedures_Patients]
GO
ALTER TABLE [dbo].[Procedures]  WITH CHECK ADD  CONSTRAINT [FK_Procedures_Technicians] FOREIGN KEY([TechnicianId])
REFERENCES [dbo].[Technicians] ([TechnicianId])
GO
ALTER TABLE [dbo].[Procedures] CHECK CONSTRAINT [FK_Procedures_Technicians]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each medical appointment' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments', @level2type=N'COLUMN',@level2name=N'AppointmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key of the doctor who requested the consultation, if there is a request within the clinic itself' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments', @level2type=N'COLUMN',@level2name=N'RequestingDoctorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key referencing the unique identifier of the patient associated with the appointment' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments', @level2type=N'COLUMN',@level2name=N'PatientId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key referencing the unique identifier of the doctor associated with the appointment' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments', @level2type=N'COLUMN',@level2name=N'DoctorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date of Appointment' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments', @level2type=N'COLUMN',@level2name=N'AppointmentDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the Status of the Query, being:
0:Scheduled
1:Confirmed
2: Cancelled' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional observation or notes related to the appointment' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments', @level2type=N'COLUMN',@level2name=N'Observation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the record  is currently active in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments', @level2type=N'COLUMN',@level2name=N'IsEnabled '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the record  was logically deleted from the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments', @level2type=N'COLUMN',@level2name=N'DeletedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores information about medical appointments or consultations' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Appointments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each availability entry.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Availabilities', @level2type=N'COLUMN',@level2name=N'AvailabilityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key referencing the doctor associated with this availability' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Availabilities', @level2type=N'COLUMN',@level2name=N'DoctorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day of the week when the doctor is available:
0: Monday
1: Tuesday
2: Wednesday
3: Thursday
4: Friday
5: Saturday
6: Sunday' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Availabilities', @level2type=N'COLUMN',@level2name=N'DayOfWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The start time of the doctors availability for the specified day.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Availabilities', @level2type=N'COLUMN',@level2name=N'StartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end time of the doctors availability for the specified day' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Availabilities', @level2type=N'COLUMN',@level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the record  is currently active in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Availabilities', @level2type=N'COLUMN',@level2name=N'IsEnabled '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the record  was logically deleted from the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Availabilities', @level2type=N'COLUMN',@level2name=N'DeletedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores information about the availability schedule for doctors.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Availabilities'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each canceled appointment.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CanceledAppointment', @level2type=N'COLUMN',@level2name=N'CanceledAppointmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for  appointment' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CanceledAppointment', @level2type=N'COLUMN',@level2name=N'AppointmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reason for the cancellation of the appointment' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CanceledAppointment', @level2type=N'COLUMN',@level2name=N'ReasonCancellation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date when the appointment was canceled' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CanceledAppointment', @level2type=N'COLUMN',@level2name=N'CancellationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'table tracks canceled medical appointments, capturing details such as appointment and cancellation dates' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CanceledAppointment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each doctor in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'DoctorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each medical specialty' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'SpecialtyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The CRM (Conselho Regional de Medicina) number of the doctor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'Crm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first name of the doctor.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' The last name or surname of the doctor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The phone number of the doctor.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The email address of the doctor.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The address of the doctor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'AddressLineOne'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The address of the doctor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'AddressLineTwo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the record  is currently active in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'IsEnabled '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the record  was logically deleted from the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors', @level2type=N'COLUMN',@level2name=N'DeletedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores information about medical doctors, their specialties, and contact details.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Doctors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único da tabela DocumentConfiguration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentParameter', @level2type=N'COLUMN',@level2name=N'DocumentParameterId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Location of the input template for document creation' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentParameter', @level2type=N'COLUMN',@level2name=N'LocalizationDocumentInput'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Location of the newly generated document' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentParameter', @level2type=N'COLUMN',@level2name=N'LocalizationDocumentOutput'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Location of the Libre Office configuration file' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentParameter', @level2type=N'COLUMN',@level2name=N'LocalizationLibreOffice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of document:
0: Prescription
1: Procedures' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentParameter', @level2type=N'COLUMN',@level2name=N'DocumentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Keeps the output settings for PDF documents' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentParameter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each medical exam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Exams', @level2type=N'COLUMN',@level2name=N'ExamId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the exam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Exams', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of the exam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Exams', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Value of Exam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Exams', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the record  is currently active in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Exams', @level2type=N'COLUMN',@level2name=N'IsEnabled '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the record  was logically deleted from the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Exams', @level2type=N'COLUMN',@level2name=N'DeletedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N': A unique identifier for each medical record forwarding activity.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Forwardings', @level2type=N'COLUMN',@level2name=N'ForwardingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK of SPecialty' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Forwardings', @level2type=N'COLUMN',@level2name=N'SpecialtyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A field used to store observations or notes related to the fowarding.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Forwardings', @level2type=N'COLUMN',@level2name=N'Observation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The table is structured to capture details about medical referrals, linking them to specific prescriptions, associating them with medical specialties, and providing space for additional observations or notes.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Forwardings'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'nique identifier for each health insurance plan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insurances', @level2type=N'COLUMN',@level2name=N'InsuranceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the health insurance plan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insurances', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of the health insurance plan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insurances', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A percentage value related to the health insurance plan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insurances', @level2type=N'COLUMN',@level2name=N'PercentageTypeOne'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Another percentage value related to the health insurance plan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insurances', @level2type=N'COLUMN',@level2name=N'PercentageTypeTwo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Another percentage value related to the health insurance plan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insurances', @level2type=N'COLUMN',@level2name=N'PercentageTypeThree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the record  is currently active in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insurances', @level2type=N'COLUMN',@level2name=N'IsEnabled '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the record  was logically deleted from the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insurances', @level2type=N'COLUMN',@level2name=N'DeletedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores information about health insurance plans or medical health plans' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insurances'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for each medication, allowing for easy reference and linkage to prescriptions.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medications', @level2type=N'COLUMN',@level2name=N'MedicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier that associates this medication with a specific prescription. It establishes a relationship between medications and the prescriptions in which they are prescribed.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medications', @level2type=N'COLUMN',@level2name=N'PrescriptionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N': The name of the medication being prescribed.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medications', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' field used to record the name of the first substitute medication, if applicable' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medications', @level2type=N'COLUMN',@level2name=N'SubstituteOne'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A field used to record the name of the second substitute medication, if applicable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medications', @level2type=N'COLUMN',@level2name=N'SubstituteTwo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Instructions related to the medication. This field provides guidance on how the medication should be taken, including dosage, frequency, and any additional directions' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medications', @level2type=N'COLUMN',@level2name=N'Instruction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The table is structured to facilitate the management and tracking of prescribed medications, including details about potential substitutes and specific usage instructions.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medications'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Patients table unique identifier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'PatientId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key referencing the unique identifier of the insurance plan associated with the procedure' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'InsuranceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of Insurance' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'InsuranceType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The  name of the patient' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last name  of the patient' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Document of Patient' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'Document'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of birth of the patient' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'DateOfBirth '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender of the patient
0: Male, 
1: Female,
2: NonBinary' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The phone one  number of the patient.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'PhoneOne'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The phone two  number of the patient.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'PhoneTwo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The email address of the patient.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The address line one of the patient.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'AddressLineOne'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The address line two of the patient.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'AddressLineTwo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the record  is currently active in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'IsEnabled '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the record  was logically deleted from the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients', @level2type=N'COLUMN',@level2name=N'DeletedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores information about patients and their medical records.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Patients'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for each prescription.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Prescriptions', @level2type=N'COLUMN',@level2name=N'PrescriptionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier that associates this prescription with a specific appointment or medical visit.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Prescriptions', @level2type=N'COLUMN',@level2name=N'AppointmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A field used to store observations or notes related to the prescription.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Prescriptions', @level2type=N'COLUMN',@level2name=N'Observation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table is structured to capture details about medical prescriptions, associating them with specific patients and doctors, recording the date of issuance and expiration, and providing space for any additional notes or instructions associated with the prescription.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Prescriptions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each medical procedure' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures', @level2type=N'COLUMN',@level2name=N'ProcedureId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key referencing the unique identifier of the patient associated with the procedure' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures', @level2type=N'COLUMN',@level2name=N'PatientId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key referencing the unique identifier of the technician performing the procedure' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures', @level2type=N'COLUMN',@level2name=N'TechnicianId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key referencing the unique identifier of the exam associated with the procedure' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures', @level2type=N'COLUMN',@level2name=N'ExamId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional observation or notes related to the procedure' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures', @level2type=N'COLUMN',@level2name=N'Observation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the record  is currently active in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures', @level2type=N'COLUMN',@level2name=N'IsEnabled '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the record  was logically deleted from the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures', @level2type=N'COLUMN',@level2name=N'DeletedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Date of Procedure' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures', @level2type=N'COLUMN',@level2name=N'ProcedureDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the Status of the Procedure, being:
0:Scheduled
1:Confirmed
2: Cancelled,
3: Completed' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores information about medical procedures and exams performed on patients' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procedures'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An auto-incremented integer serving as the primary key for the table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RefreshTokens ', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A string representing the unique identifier of the user associated with the refresh token.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RefreshTokens ', @level2type=N'COLUMN',@level2name=N'UserId '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A string storing the refresh token itself.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RefreshTokens ', @level2type=N'COLUMN',@level2name=N'Token'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' A string representing the unique identifier of the associated JWT (JSON Web Token).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RefreshTokens ', @level2type=N'COLUMN',@level2name=N'JwtId '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean flag indicating whether the refresh token has been used.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RefreshTokens ', @level2type=N'COLUMN',@level2name=N'IsUsed '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean flag indicating whether the refresh token has been revoked.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RefreshTokens ', @level2type=N'COLUMN',@level2name=N'IsRevoked '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A datetime value representing the date and time when the refresh token was added to the database' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RefreshTokens ', @level2type=N'COLUMN',@level2name=N'AddedDate '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A datetime value representing the expiration date and time of the refresh token.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RefreshTokens ', @level2type=N'COLUMN',@level2name=N'ExpiryDate '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'he RefreshTokens table is designed to store information related to refresh tokens used in token-based authentication systems' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RefreshTokens '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each medical specialty' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Specialties', @level2type=N'COLUMN',@level2name=N'SpecialtyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the medical specialty' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Specialties', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'escription of the medical specialty' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Specialties', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Value of Consultation ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Specialties', @level2type=N'COLUMN',@level2name=N'ConsultationValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the record  is currently active in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Specialties', @level2type=N'COLUMN',@level2name=N'IsEnabled '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the record  was logically deleted from the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Specialties', @level2type=N'COLUMN',@level2name=N'DeletedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores information about medical specialties' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Specialties'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each Technician' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'TechnicianId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first name of the technician' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last name or surname of the technician' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The email address of the technician' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The phone number of the technician' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The address line one  of the patient.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'AddressLineOne'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The address line two of the patient.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'AddressLineTwo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of Insurance' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'InsuranceType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the record  is currently active in the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'IsEnabled '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the record  was logically deleted from the system' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians', @level2type=N'COLUMN',@level2name=N'DeletedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores information about technicians or technical staff' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Technicians'
GO
USE [master]
GO
ALTER DATABASE [MedicalClinicDB] SET  READ_WRITE 
GO
