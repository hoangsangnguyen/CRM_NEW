USE [VinoDB]
GO
/****** Object:  Table [dbo].[AirExps]    Script Date: 07/29/2018 10:26:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Service] [nvarchar](max) NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[CommodityId] [int] NOT NULL,
	[MawbNumber] [nvarchar](max) NULL,
	[TypeOfBillId] [int] NOT NULL,
	[FlightNumber] [nvarchar](max) NULL,
	[FlyDate] [datetimeoffset](7) NOT NULL,
	[OpicId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[OriginPortId] [int] NOT NULL,
	[TransitPortId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[CarrierId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[DestinationId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AirExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AirImps]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirImps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[MawbNumber] [nvarchar](max) NOT NULL,
	[FlightNumber] [nvarchar](max) NOT NULL,
	[FLyDate] [datetimeoffset](7) NOT NULL,
	[CommodityId] [int] NOT NULL,
	[TypeOfBillId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[OpIcId] [int] NOT NULL,
	[Service] [nvarchar](max) NULL,
	[AolId] [int] NOT NULL,
	[DeliveryId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[AirlineId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[AodId] [int] NOT NULL,
	[Routing] [nvarchar](max) NOT NULL,
	[Scn] [nvarchar](max) NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AirImps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carriers]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carriers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FullEnglishName] [nvarchar](max) NOT NULL,
	[Contact] [nvarchar](max) NULL,
	[Cell] [nvarchar](max) NULL,
	[CountryId] [int] NOT NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Carriers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Containers]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Containers](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[ContainerNo] [nvarchar](max) NOT NULL,
	[SealNo] [nvarchar](max) NULL,
	[Quantity] [float] NOT NULL,
	[UnitId] [int] NOT NULL,
	[DescriptionOfGoods] [nvarchar](max) NULL,
	[Nw] [float] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Containers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CrmContacts]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrmContacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EnglishName] [nvarchar](50) NOT NULL,
	[PositionId] [int] NOT NULL,
	[HomeAddress] [nvarchar](max) NULL,
	[CellPhone] [nvarchar](max) NULL,
	[HomePhone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CompanyExt] [nvarchar](max) NULL,
	[Signature] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[Birthday] [datetimeoffset](7) NOT NULL,
	[MarriageStatus] [bit] NOT NULL,
	[SpouseName] [nvarchar](max) NULL,
	[SpouseBirthday] [datetimeoffset](7) NOT NULL,
	[FieldInterested] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.CrmContacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CrmCustomers]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrmCustomers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FullEngishName] [nvarchar](max) NULL,
	[FullVietNamName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ContactId] [int] NOT NULL,
	[WorkPhone] [nvarchar](max) NULL,
	[HomePhone] [nvarchar](max) NULL,
	[FaxNo] [nvarchar](max) NULL,
	[LocationId] [int] NOT NULL,
	[Taxcode] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[Website] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.CrmCustomers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Districts]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceId] [int] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Districts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailAccounts]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](512) NOT NULL,
	[DisplayName] [nvarchar](512) NOT NULL,
	[Host] [nvarchar](512) NOT NULL,
	[Port] [int] NOT NULL,
	[Username] [nvarchar](512) NOT NULL,
	[Password] [nvarchar](512) NOT NULL,
	[EnableSsl] [bit] NOT NULL,
	[UseDefaultCredentials] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.EmailAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeDatas]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDatas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[LastUpdatedAt] [datetimeoffset](7) NOT NULL,
	[Settings] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.EmployeeDatas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ProvinceId] [int] NULL,
	[DistrictId] [int] NULL,
	[Phone] [nvarchar](max) NULL,
	[DayOfBirth] [datetime] NULL,
	[Email] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
	[ImageRecordId] [int] NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[Apps] [nvarchar](max) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[IsValidated] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FclExps]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FclExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[BkgNumber] [nvarchar](max) NOT NULL,
	[Mbl] [nvarchar](max) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[PoNumber] [nvarchar](max) NOT NULL,
	[MblTypeId] [int] NOT NULL,
	[VesselId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[PolId] [int] NOT NULL,
	[FreightId] [int] NOT NULL,
	[OpIcId] [int] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[SlinesId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[Container] [nvarchar](max) NULL,
	[CommodityId] [int] NOT NULL,
	[PodId] [int] NOT NULL,
	[Service] [nvarchar](max) NOT NULL,
	[Gw] [float] NOT NULL,
	[Qty] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.FclExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FclImps]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FclImps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[MblNumber] [nvarchar](max) NOT NULL,
	[PolId] [int] NOT NULL,
	[Service] [nvarchar](max) NOT NULL,
	[MblTypeId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[OpIcId] [int] NOT NULL,
	[ScName] [nvarchar](max) NOT NULL,
	[PoNumber] [nvarchar](max) NOT NULL,
	[PodId] [int] NOT NULL,
	[Container] [nvarchar](max) NOT NULL,
	[CommodityId] [int] NOT NULL,
	[SlinesId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[VesselId] [int] NOT NULL,
	[VoyageId] [int] NOT NULL,
	[DeliveryId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.FclImps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HblFclExps]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HblFclExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FclExpId] [int] NOT NULL,
	[BlNumber] [nvarchar](max) NOT NULL,
	[BookingNumber] [nvarchar](max) NOT NULL,
	[HblType] [int] NOT NULL,
	[ShipperId] [int] NOT NULL,
	[ConsigneeId] [int] NOT NULL,
	[NotifyPartyId] [int] NOT NULL,
	[LocalVessel] [int] NOT NULL,
	[PlaceOfReceiptId] [int] NOT NULL,
	[OceanVessel] [int] NULL,
	[PortOfLoaingId] [int] NOT NULL,
	[PortOfDischargeId] [int] NOT NULL,
	[TranshipmentPortId] [int] NOT NULL,
	[Container] [nvarchar](max) NULL,
	[NumberOfPackage] [int] NOT NULL,
	[QtyOfContainer] [nvarchar](max) NULL,
	[PoNumber] [nvarchar](max) NULL,
	[DescriptionOfGoods] [nvarchar](max) NULL,
	[GrossWeight] [float] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Measurement] [float] NOT NULL,
	[OnBoardStatus] [nvarchar](max) NULL,
	[ForwardingAgent] [nvarchar](max) NOT NULL,
	[FreightAmount] [float] NOT NULL,
	[ExRef] [datetimeoffset](7) NULL,
	[ReferenceNumber] [float] NOT NULL,
	[FinalDestinationId] [int] NOT NULL,
	[PlaceOfDeliveryId] [int] NOT NULL,
	[CountryOfOriginId] [int] NOT NULL,
	[TypeOfMoveId] [int] NULL,
	[ClosingDate] [datetimeoffset](7) NOT NULL,
	[FreightPayableId] [int] NULL,
	[NumberOfOriginal] [int] NOT NULL,
	[SailingDate] [datetimeoffset](7) NOT NULL,
	[DeliveryOfGoodsId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[PlaceOfIssueId] [int] NULL,
	[IssueDate] [datetimeoffset](7) NOT NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.HblFclExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HblLclExps]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HblLclExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LclExpId] [int] NOT NULL,
	[BlNumber] [nvarchar](max) NOT NULL,
	[BookingNumber] [nvarchar](max) NOT NULL,
	[HblType] [int] NOT NULL,
	[ShipperId] [int] NOT NULL,
	[ConsigneeId] [int] NOT NULL,
	[NotifyPartyId] [int] NOT NULL,
	[LocalVessel] [int] NOT NULL,
	[PlaceOfReceiptId] [int] NOT NULL,
	[OceanVessel] [int] NULL,
	[PortOfLoaingId] [int] NOT NULL,
	[PortOfDischargeId] [int] NOT NULL,
	[TranshipmentPortId] [int] NOT NULL,
	[Container] [nvarchar](max) NULL,
	[NumberOfPackage] [int] NOT NULL,
	[QtyOfContainer] [nvarchar](max) NULL,
	[PoNumber] [nvarchar](max) NULL,
	[DescriptionOfGoods] [nvarchar](max) NULL,
	[GrossWeight] [float] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Measurement] [float] NOT NULL,
	[OnBoardStatus] [nvarchar](max) NULL,
	[ForwardingAgent] [nvarchar](max) NOT NULL,
	[FreightAmount] [float] NOT NULL,
	[ExRef] [datetimeoffset](7) NULL,
	[ReferenceNumber] [float] NOT NULL,
	[FinalDestinationId] [int] NOT NULL,
	[PlaceOfDeliveryId] [int] NOT NULL,
	[CountryOfOriginId] [int] NOT NULL,
	[TypeOfMoveId] [int] NULL,
	[ClosingDate] [datetimeoffset](7) NOT NULL,
	[FreightPayableId] [int] NULL,
	[NumberOfOriginal] [int] NOT NULL,
	[SailingDate] [datetimeoffset](7) NOT NULL,
	[DeliveryOfGoodsId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[PlaceOfIssueId] [int] NULL,
	[IssueDate] [datetimeoffset](7) NOT NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.HblLclExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImageRecords]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[RelativePath] [nvarchar](max) NULL,
	[AbsolutePath] [nvarchar](max) NULL,
	[IsExternal] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ImageRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LclExps]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LclExps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[BkgNumber] [nvarchar](max) NOT NULL,
	[MblNumber] [nvarchar](max) NOT NULL,
	[MblTypeId] [int] NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[OpIcId] [int] NOT NULL,
	[VesselId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[PolId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
	[Packages] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[CoLoaderId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[PodId] [int] NOT NULL,
	[FreightId] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.LclExps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LclImps]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LclImps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Etd] [datetimeoffset](7) NOT NULL,
	[Eta] [datetimeoffset](7) NOT NULL,
	[MblNumber] [nvarchar](max) NOT NULL,
	[MblTypeId] [int] NOT NULL,
	[PolId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[OpIcId] [int] NOT NULL,
	[ScName] [nvarchar](max) NOT NULL,
	[VesselId] [int] NOT NULL,
	[PodId] [int] NOT NULL,
	[Packages] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Service] [nvarchar](max) NOT NULL,
	[IsFinish] [bit] NOT NULL,
	[SlinesId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[VoyageId] [int] NOT NULL,
	[DeliveryId] [int] NOT NULL,
	[Gw] [float] NOT NULL,
	[Cbm] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.LclImps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginTokens]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Token] [nvarchar](1024) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.LoginTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogLevel] [int] NOT NULL,
	[ShortMessage] [nvarchar](max) NULL,
	[FullMessage] [nvarchar](max) NULL,
	[Context] [nvarchar](max) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lookups]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Code] [nvarchar](32) NOT NULL,
	[Order] [int] NOT NULL,
	[Title] [nvarchar](256) NULL,
	[App] [nvarchar](3) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Lookups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageTemplates]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTemplates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[BccEmailAddresses] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[DelayBeforeSend] [int] NULL,
	[AttachedDownloadId] [int] NOT NULL,
	[EmailAccountId] [int] NOT NULL,
	[Delay] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.MessageTemplates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderGenCodes]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderGenCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrefix] [nvarchar](max) NULL,
	[CurrentDate] [datetimeoffset](7) NOT NULL,
	[Begin] [int] NOT NULL,
	[CurrentNumber] [int] NOT NULL,
	[End] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.OrderGenCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ports]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PortCode] [nvarchar](max) NOT NULL,
	[PortName] [nvarchar](max) NOT NULL,
	[NationalityId] [int] NOT NULL,
	[ZoneId] [int] NOT NULL,
	[LocalZone] [nvarchar](max) NOT NULL,
	[ModeId] [int] NOT NULL,
	[UpdateName] [nvarchar](max) NULL,
	[UpdateAt] [datetimeoffset](7) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Ports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provinces]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provinces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Provinces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QueuedEmails]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueuedEmails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Priority] [int] NOT NULL,
	[From] [nvarchar](max) NULL,
	[FromName] [nvarchar](max) NULL,
	[To] [nvarchar](max) NULL,
	[ToName] [nvarchar](max) NULL,
	[CC] [nvarchar](max) NULL,
	[Bcc] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[AttachmentFilePath] [nvarchar](max) NULL,
	[AttachmentFileName] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[SentTries] [int] NOT NULL,
	[SentOn] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.QueuedEmails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topics]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ImageId] [int] NULL,
	[Type] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_Role]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_Role](
	[SystemName] [nvarchar](128) NOT NULL,
	[Display] [nvarchar](32) NULL,
	[Active] [bit] NOT NULL,
	[Permissons] [nvarchar](1024) NULL,
 CONSTRAINT [PK_dbo.z_Role] PRIMARY KEY CLUSTERED 
(
	[SystemName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_Setting]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_Setting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.z_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_User]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](64) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[AvatarUrl] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
	[Roles] [nvarchar](max) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.z_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_UserClaim]    Script Date: 07/29/2018 10:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_UserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimName] [nvarchar](32) NULL,
	[ClaimValue] [nvarchar](1024) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.z_UserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Carriers] ON 

INSERT [dbo].[Carriers] ([Id], [Code], [Name], [FullEnglishName], [Contact], [Cell], [CountryId], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, N'CL180729001', N'Sang1', N'SangNguyen', NULL, NULL, 66, NULL, NULL, CAST(N'2018-07-29T09:36:34.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[Carriers] OFF
SET IDENTITY_INSERT [dbo].[CrmContacts] ON 

INSERT [dbo].[CrmContacts] ([Id], [ContactId], [FirstName], [LastName], [EnglishName], [PositionId], [HomeAddress], [CellPhone], [HomePhone], [Email], [CompanyExt], [Signature], [DepartmentId], [Birthday], [MarriageStatus], [SpouseName], [SpouseBirthday], [FieldInterested], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, N'CT180729001', N'Sang1', N'Nguyen', N'Sang1nguyen', 16, NULL, NULL, NULL, NULL, NULL, NULL, 25, CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), 0, NULL, CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, NULL, CAST(N'2018-07-29T09:37:11.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[CrmContacts] OFF
SET IDENTITY_INSERT [dbo].[CrmCustomers] ON 

INSERT [dbo].[CrmCustomers] ([Id], [CustomerId], [Name], [FullEngishName], [FullVietNamName], [Address], [ContactId], [WorkPhone], [HomePhone], [FaxNo], [LocationId], [Taxcode], [CategoryId], [Website], [Email], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (2, N'CS180729002', N'Sang1', N'Sang1Nguyen', N'Hoàng Sang1', N'2/7 đường 106 phường Tăng Nhơn Phú A', 1, N'1628886014', NULL, NULL, 84, NULL, 86, NULL, NULL, NULL, NULL, CAST(N'2018-07-29T09:37:32.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[CrmCustomers] OFF
SET IDENTITY_INSERT [dbo].[FclExps] ON 

INSERT [dbo].[FclExps] ([Id], [JobId], [Created], [Etd], [BkgNumber], [Mbl], [Eta], [PoNumber], [MblTypeId], [VesselId], [ShipmentId], [PolId], [FreightId], [OpIcId], [IsFinish], [SlinesId], [AgentId], [Container], [CommodityId], [PodId], [Service], [Gw], [Qty], [Cbm], [Notes], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, N'FLF1807/0001', CAST(N'2018-07-29T00:00:00.0000000+07:00' AS DateTimeOffset), CAST(N'2018-07-29T00:00:00.0000000+07:00' AS DateTimeOffset), N'123', N'1628886014', CAST(N'2018-07-29T00:00:00.0000000+07:00' AS DateTimeOffset), N'1234', 70, 74, 33, 1, 79, 1, 0, 1, 1, N'[{"Id":"8bb80737-8c5c-4b9f-aea0-f77112046633","Type":"d22","TypeName":null,"ContainerNo":"mng","SealNo":"789","Quantity":3.0,"UnitId":42,"UnitName":null,"DescriptionOfGoods":null,"Nw":3.0,"Gw":3.0,"Cbm":3.0},{"Id":"9cd07dd2-4186-4dd2-be44-9be3ad1140df","Type":"d21","TypeName":null,"ContainerNo":"def","SealNo":"456","Quantity":2.0,"UnitId":41,"UnitName":null,"DescriptionOfGoods":null,"Nw":2.0,"Gw":2.0,"Cbm":2.0},{"Id":"88adca65-2898-464b-9d2f-d81927b3cd82","Type":"d20","TypeName":null,"ContainerNo":"abc","SealNo":"123","Quantity":1.0,"UnitId":40,"UnitName":null,"DescriptionOfGoods":null,"Nw":1.0,"Gw":1.0,"Cbm":1.0}]', 4, 1, N'no service', 6, 6, 6, NULL, NULL, NULL, CAST(N'2018-07-29T09:38:04.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[FclExps] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (1, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-29T09:32:10.1146433+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (2, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-29T09:35:45.3921059+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (3, 40, N'The parameters dictionary contains a null entry for parameter ''id'' of non-nullable type ''System.Int32'' for method ''System.Web.Mvc.ActionResult ContainerAddPopup(System.String, Int32)'' in ''Vino.Server.Web.Areas.Admin.Controllers.ContainerController''. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
Parameter name: parameters', N'System.ArgumentException: The parameters dictionary contains a null entry for parameter ''id'' of non-nullable type ''System.Int32'' for method ''System.Web.Mvc.ActionResult ContainerAddPopup(System.String, Int32)'' in ''Vino.Server.Web.Areas.Admin.Controllers.ContainerController''. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
Parameter name: parameters
   at System.Web.Mvc.ActionDescriptor.ExtractParameterFromDictionary(ParameterInfo parameterInfo, IDictionary`2 parameters, MethodInfo methodInfo)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', N'', CAST(N'2018-07-29T09:35:46.0878101+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (4, 40, N'An error occurred while updating the entries. See the inner exception for details.', N'System.Data.Entity.Infrastructure.DbUpdateException: An error occurred while updating the entries. See the inner exception for details. ---> System.Data.Entity.Core.UpdateException: An error occurred while updating the entries. See the inner exception for details. ---> System.Data.SqlClient.SqlException: Cannot insert the value NULL into column ''CategoryId'', table ''VinoDB.dbo.CrmCustomers''; column does not allow nulls. INSERT fails.
The statement has been terminated.
   at System.Data.SqlClient.SqlCommand.<>c.<ExecuteDbDataReaderAsync>b__180_0(Task`1 result)
   at System.Threading.Tasks.ContinuationResultTaskFromResultTask`2.InnerInvoke()
   at System.Threading.Tasks.Task.Execute()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Utilities.TaskExtensions.CultureAwaiter`1.GetResult()
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
   --- End of inner exception stack trace ---
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.SqlServer.DefaultSqlExecutionStrategy.<ExecuteAsyncImplementation>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()
   --- End of inner exception stack trace ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Services.MainServices.BaseService.GenericRepository`3.<CreateAsync>d__5.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\BaseService\GenericRepository.cs:line 59
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.CustomersController.<Create>d__9.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\CustomersController.cs:line 104
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.InvokeEndHandler(IAsyncResult ar)
   at System.Web.HttpApplication.CallHandlerExecutionStep.OnAsyncHandlerCompletion(IAsyncResult ar)', N'', CAST(N'2018-07-29T09:37:27.0001415+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (5, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-29T09:40:36.1564943+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (6, 40, N'A second operation started on this context before a previous asynchronous operation completed. Use ''await'' to ensure that any asynchronous operations have completed before calling another method on this context. Any instance members are not guaranteed to be thread safe.', N'System.NotSupportedException: A second operation started on this context before a previous asynchronous operation completed. Use ''await'' to ensure that any asynchronous operations have completed before calling another method on this context. Any instance members are not guaranteed to be thread safe.
   at System.Data.Entity.Internal.ThrowingMonitor.EnsureNotEntered()
   at System.Data.Entity.Core.Objects.ObjectQuery`1.System.Collections.Generic.IEnumerable<T>.GetEnumerator()
   at System.Linq.Enumerable.FirstOrDefault[TSource](IEnumerable`1 source)
   at System.Data.Entity.Core.Objects.ELinq.ObjectQueryProvider.<GetElementFunction>b__1[TResult](IEnumerable`1 sequence)
   at System.Data.Entity.Core.Objects.ELinq.ObjectQueryProvider.ExecuteSingle[TResult](IEnumerable`1 query, Expression queryRoot)
   at System.Data.Entity.Core.Objects.ELinq.ObjectQueryProvider.System.Linq.IQueryProvider.Execute[TResult](Expression expression)
   at System.Data.Entity.Internal.Linq.DbQueryProvider.Execute[TResult](Expression expression)
   at System.Linq.Queryable.FirstOrDefault[TSource](IQueryable`1 source, Expression`1 predicate)
   at Vino.Server.Services.MainServices.CRM.FclExp.FclExpService.<UpdateContainer>d__6.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\CRM\FclExp\FclExpService.cs:line 143
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.ContainerController.<Edit>d__5.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\ContainerController.cs:line 73
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', N'', CAST(N'2018-07-29T09:43:23.8002814+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (7, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-29T10:01:17.4240290+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (8, 40, N'The ''Qty'' property on ''FclExp'' could not be set to a ''null'' value. You must set this property to a non-null value of type ''System.Double''. ', N'System.Data.ConstraintException: The ''Qty'' property on ''FclExp'' could not be set to a ''null'' value. You must set this property to a non-null value of type ''System.Double''. 
   at System.Data.Entity.Core.Common.Internal.Materialization.Shaper.ErrorHandlingValueReader`1.GetValue(DbDataReader reader, Int32 ordinal)
   at System.Data.Entity.Core.Common.Internal.Materialization.Shaper.GetPropertyValueWithErrorHandling[TProperty](Int32 ordinal, String propertyName, String typeName)
   at lambda_method(Closure , Shaper )
   at System.Data.Entity.Core.Common.Internal.Materialization.Coordinator`1.ReadNextElement(Shaper shaper)
   at System.Data.Entity.Core.Common.Internal.Materialization.Shaper`1.SimpleEnumerator.<MoveNextAsync>d__4.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Internal.LazyAsyncEnumerator`1.<FirstMoveNextAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Infrastructure.IDbAsyncEnumerableExtensions.<ForEachAsync>d__5`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Services.MainServices.CRM.FclExp.FclExpService.<SearchModels>d__3.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\CRM\FclExp\FclExpService.cs:line 58
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.FclExpsController.<List>d__7.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\FclExpsController.cs:line 61
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.InvokeEndHandler(IAsyncResult ar)
   at System.Web.HttpApplication.CallHandlerExecutionStep.OnAsyncHandlerCompletion(IAsyncResult ar)', N'', CAST(N'2018-07-29T10:01:29.1696874+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (9, 40, N'The ''Qty'' property on ''FclExp'' could not be set to a ''null'' value. You must set this property to a non-null value of type ''System.Double''. ', N'System.Data.ConstraintException: The ''Qty'' property on ''FclExp'' could not be set to a ''null'' value. You must set this property to a non-null value of type ''System.Double''. 
   at System.Data.Entity.Core.Common.Internal.Materialization.Shaper.ErrorHandlingValueReader`1.GetValue(DbDataReader reader, Int32 ordinal)
   at System.Data.Entity.Core.Common.Internal.Materialization.Shaper.GetPropertyValueWithErrorHandling[TProperty](Int32 ordinal, String propertyName, String typeName)
   at lambda_method(Closure , Shaper )
   at System.Data.Entity.Core.Common.Internal.Materialization.Coordinator`1.ReadNextElement(Shaper shaper)
   at System.Data.Entity.Core.Common.Internal.Materialization.Shaper`1.SimpleEnumerator.<MoveNextAsync>d__4.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Internal.LazyAsyncEnumerator`1.<FirstMoveNextAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Infrastructure.IDbAsyncEnumerableExtensions.<ForEachAsync>d__5`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Services.MainServices.CRM.FclExp.FclExpService.<SearchModels>d__3.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\CRM\FclExp\FclExpService.cs:line 58
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.FclExpsController.<List>d__7.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\FclExpsController.cs:line 61
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.InvokeEndHandler(IAsyncResult ar)
   at System.Web.HttpApplication.CallHandlerExecutionStep.OnAsyncHandlerCompletion(IAsyncResult ar)', N'', CAST(N'2018-07-29T10:01:43.1624357+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (10, 40, N'The ''Qty'' property on ''FclExp'' could not be set to a ''null'' value. You must set this property to a non-null value of type ''System.Double''. ', N'System.Data.ConstraintException: The ''Qty'' property on ''FclExp'' could not be set to a ''null'' value. You must set this property to a non-null value of type ''System.Double''. 
   at System.Data.Entity.Core.Common.Internal.Materialization.Shaper.ErrorHandlingValueReader`1.GetValue(DbDataReader reader, Int32 ordinal)
   at System.Data.Entity.Core.Common.Internal.Materialization.Shaper.GetPropertyValueWithErrorHandling[TProperty](Int32 ordinal, String propertyName, String typeName)
   at lambda_method(Closure , Shaper )
   at System.Data.Entity.Core.Common.Internal.Materialization.Coordinator`1.ReadNextElement(Shaper shaper)
   at System.Data.Entity.Core.Common.Internal.Materialization.Shaper`1.SimpleEnumerator.<MoveNextAsync>d__4.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Internal.LazyAsyncEnumerator`1.<FirstMoveNextAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Data.Entity.Infrastructure.IDbAsyncEnumerableExtensions.<ForEachAsync>d__5`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Services.MainServices.CRM.FclExp.FclExpService.<SearchModels>d__3.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\CRM\FclExp\FclExpService.cs:line 58
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.FclExpsController.<List>d__7.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\FclExpsController.cs:line 61
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.InvokeEndHandler(IAsyncResult ar)
   at System.Web.HttpApplication.CallHandlerExecutionStep.OnAsyncHandlerCompletion(IAsyncResult ar)', N'', CAST(N'2018-07-29T10:01:55.2093793+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (11, 40, N'A second operation started on this context before a previous asynchronous operation completed. Use ''await'' to ensure that any asynchronous operations have completed before calling another method on this context. Any instance members are not guaranteed to be thread safe.', N'System.NotSupportedException: A second operation started on this context before a previous asynchronous operation completed. Use ''await'' to ensure that any asynchronous operations have completed before calling another method on this context. Any instance members are not guaranteed to be thread safe.
   at System.Data.Entity.Internal.ThrowingMonitor.EnsureNotEntered()
   at System.Data.Entity.Core.Objects.ObjectQuery`1.System.Collections.Generic.IEnumerable<T>.GetEnumerator()
   at System.Linq.Enumerable.FirstOrDefault[TSource](IEnumerable`1 source)
   at System.Data.Entity.Core.Objects.ELinq.ObjectQueryProvider.<GetElementFunction>b__1[TResult](IEnumerable`1 sequence)
   at System.Data.Entity.Core.Objects.ELinq.ObjectQueryProvider.ExecuteSingle[TResult](IEnumerable`1 query, Expression queryRoot)
   at System.Data.Entity.Core.Objects.ELinq.ObjectQueryProvider.System.Linq.IQueryProvider.Execute[TResult](Expression expression)
   at System.Data.Entity.Internal.Linq.DbQueryProvider.Execute[TResult](Expression expression)
   at System.Linq.Queryable.FirstOrDefault[TSource](IQueryable`1 source, Expression`1 predicate)
   at Vino.Server.Services.MainServices.CRM.FclExp.FclExpService.<DeleteContainer>d__7.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\CRM\FclExp\FclExpService.cs:line 169
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.ContainerController.<Delete>d__6.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\ContainerController.cs:line 84
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', N'', CAST(N'2018-07-29T10:03:53.6398034+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (12, 40, N'A second operation started on this context before a previous asynchronous operation completed. Use ''await'' to ensure that any asynchronous operations have completed before calling another method on this context. Any instance members are not guaranteed to be thread safe.', N'System.NotSupportedException: A second operation started on this context before a previous asynchronous operation completed. Use ''await'' to ensure that any asynchronous operations have completed before calling another method on this context. Any instance members are not guaranteed to be thread safe.
   at System.Data.Entity.Internal.ThrowingMonitor.EnsureNotEntered()
   at System.Data.Entity.Core.Objects.ObjectQuery`1.System.Collections.Generic.IEnumerable<T>.GetEnumerator()
   at System.Linq.Enumerable.FirstOrDefault[TSource](IEnumerable`1 source)
   at System.Data.Entity.Core.Objects.ELinq.ObjectQueryProvider.<GetElementFunction>b__1[TResult](IEnumerable`1 sequence)
   at System.Data.Entity.Core.Objects.ELinq.ObjectQueryProvider.ExecuteSingle[TResult](IEnumerable`1 query, Expression queryRoot)
   at System.Data.Entity.Core.Objects.ELinq.ObjectQueryProvider.System.Linq.IQueryProvider.Execute[TResult](Expression expression)
   at System.Data.Entity.Internal.Linq.DbQueryProvider.Execute[TResult](Expression expression)
   at System.Linq.Queryable.FirstOrDefault[TSource](IQueryable`1 source, Expression`1 predicate)
   at Vino.Server.Services.MainServices.CRM.FclExp.FclExpService.<DeleteContainer>d__7.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\CRM\FclExp\FclExpService.cs:line 169
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.ContainerController.<Delete>d__6.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\ContainerController.cs:line 84
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', N'', CAST(N'2018-07-29T10:04:32.0746666+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (13, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-29T10:05:58.2508801+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (14, 40, N'A second operation started on this context before a previous asynchronous operation completed. Use ''await'' to ensure that any asynchronous operations have completed before calling another method on this context. Any instance members are not guaranteed to be thread safe.', N'System.NotSupportedException: A second operation started on this context before a previous asynchronous operation completed. Use ''await'' to ensure that any asynchronous operations have completed before calling another method on this context. Any instance members are not guaranteed to be thread safe.
   at System.Data.Entity.Internal.ThrowingMonitor.EnsureNotEntered()
   at System.Data.Entity.Core.Objects.ObjectQuery`1.System.Data.Entity.Infrastructure.IDbAsyncEnumerable<T>.GetAsyncEnumerator()
   at System.Data.Entity.Infrastructure.IDbAsyncEnumerableExtensions.<FirstOrDefaultAsync>d__25`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Vino.Server.Services.MainServices.CRM.FclExp.FclExpService.<DeleteContainer>d__7.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Services\MainServices\CRM\FclExp\FclExpService.cs:line 169
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.GetResult()
   at Vino.Server.Web.Areas.Admin.Controllers.ContainerController.<Delete>d__6.MoveNext() in D:\Workspace\Work\DoAnThucTap\CRM_NEW\New folder\Server\Server.Web\Areas\Admin\Controllers\ContainerController.cs:line 84
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecuteCore>b__1d(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<BeginExecute>b__15(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__5(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', N'', CAST(N'2018-07-29T10:06:17.0432584+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (15, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-29T10:09:57.7943460+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (16, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-29T10:20:19.0600426+07:00' AS DateTimeOffset), 0)
INSERT [dbo].[Logs] ([Id], [LogLevel], [ShortMessage], [FullMessage], [Context], [CreatedAt], [Deleted]) VALUES (17, 20, N'MasterAdmin Started!', N'', N'', CAST(N'2018-07-29T10:24:21.3762079+07:00' AS DateTimeOffset), 0)
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Lookups] ON 

INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (1, 20, N'0', 0, N'-', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (2, 20, N'1', 0, N'Nam', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (3, 20, N'2', 0, N'Nữ', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (4, 45, N'1', 0, N'Seafood', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (5, 45, N'2', 0, N'Electtronics & Electrical material', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (6, 45, N'3', 0, N'Coffee', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (7, 45, N'4', 0, N'Paper & Chemical Products', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (8, 45, N'5', 0, N'Marble & Tiles', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (9, 45, N'6', 0, N'Rice', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (10, 45, N'7', 0, N'Funiture, Frames, Wood Articles', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (11, 45, N'8', 0, N'Machinery, Utensils & Metalware', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (12, 45, N'9', 0, N'Glass, Ceramic and Plasticware', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (13, 45, N'10', 0, N'Textiles, Gaments and accessories', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (14, 45, N'11', 0, N'Foods & Beverages', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (15, 45, N'12', 0, N'Others', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (16, 46, N'1', 0, N'Oversea Manager', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (17, 46, N'2', 0, N'Nomination', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (18, 46, N'3', 0, N'Account Manager', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (19, 46, N'4', 0, N'General Director', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (20, 46, N'5', 0, N'Accountant', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (21, 46, N'6', 0, N'Staff', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (22, 46, N'7', 0, N'Operation Executive', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (23, 46, N'8', 0, N'Director', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (24, 46, N'8', 0, N'FLC', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (25, 47, N'DP001', 0, N'BOD', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (26, 47, N'DP002', 0, N'Sales', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (27, 47, N'DP003', 0, N'Accounting', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (28, 47, N'DP004', 0, N'Operation', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (29, 47, N'DP005', 0, N'Oversea', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (30, 47, N'DP006', 0, N'HAN Office', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (31, 47, N'DP007', 0, N'FLC', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (32, 47, N'DP008', 0, N'Nomination', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (33, 48, N'1', 0, N'FREE-HAND', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (34, 48, N'2', 0, N'NOMINATED', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (35, 49, N'1', 0, N'FREIGHT PREPAID', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (36, 49, N'2', 0, N'FREIGHT COLLECT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (37, 50, N'1', 0, N'COPY', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (38, 50, N'2', 0, N'ORIGINAL', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (39, 50, N'3', 0, N'SURRENDERED', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (40, 51, N'1', 0, N'BAG', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (41, 51, N'2', 0, N'CBM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (42, 51, N'3', 0, N'BOXES', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (43, 51, N'4', 0, N'BL', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (44, 52, N'1', 0, N'DEPOT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (45, 52, N'2', 0, N'SEA&AIR', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (46, 52, N'3', 0, N'SEA&AIR&INLAND&DEPOT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (47, 52, N'4', 0, N'AIR&INLAND', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (48, 52, N'5', 0, N'INLAND&DEPOT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (49, 52, N'6', 0, N'SEA&DEPOT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (50, 52, N'7', 0, N'SEA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (51, 52, N'8', 0, N'AIR', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (52, 52, N'8', 0, N'SEA&AIR&INLAND', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (53, 52, N'9', 0, N'EXPRESS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (54, 53, N'1', 0, N'AFRICA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (55, 53, N'2', 0, N'Central America', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (56, 53, N'3', 0, N'Oceania', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (57, 53, N'4', 0, N'South Asia', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (58, 53, N'5', 0, N'EUROPE', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (59, 53, N'6', 0, N'MIDDLE EAST', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (60, 53, N'7', 0, N'North Asia', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (61, 53, N'8', 0, N'North America', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (62, 53, N'9', 0, N'South America', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (63, 53, N'10', 0, N'ASIA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (64, 53, N'11', 0, N'OTHERS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (65, 54, N'1', 0, N'ARMENIA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (66, 54, N'2', 0, N'ARUBA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (67, 54, N'3', 0, N'AUSTRIA', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (68, 54, N'4', 0, N'AZERBAIJAN', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (69, 54, N'5', 0, N'BAHAMAS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (70, 55, N'1', 0, N'COPY', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (71, 55, N'2', 0, N'ORIGINAL', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (72, 55, N'3', 0, N'SEAWAY B/L', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (73, 55, N'4', 0, N'SURRENDERED', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (74, 56, N'1', 0, N'BANI BHUM V.773S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (75, 56, N'2', 0, N'EVER POWER V.0112-234S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (76, 56, N'3', 0, N'HANSA HOMBURG V.163S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (77, 56, N'4', 0, N'HEUNG-A JANICE V. 0072N', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (78, 56, N'5', 0, N'LEDA TRADER V.0021N', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (79, 57, N'1', 0, N'COLLECT', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (80, 57, N'1', 0, N'PREPAID', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (81, 58, N'1', 0, N'0020S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (82, 58, N'2', 0, N'17004S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (83, 58, N'3', 0, N'17006S', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (84, 59, N'domestic', 0, N'Domestic', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (85, 59, N'overseas', 0, N'Overseas', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (86, 60, N'agent-domestic', 0, N'AGENT - DOMESTIC', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (87, 60, N'agent-overseas', 0, N'AGENT - OVERSEAS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (88, 60, N'co-loader', 0, N'CO-LOADER', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (89, 60, N'direct-consignee', 0, N'DIRECT CONSIGNEE', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (90, 60, N'direct-customer', 0, N'DIRECT CUSTOMER', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (91, 60, N'direct-shipper', 0, N'DIRECT SHIPPER', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (92, 61, N'FCL/FCL-CY/CY', 0, N'FCL/FCL-CY/CY', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (93, 61, N'LCL/LCL-CFS/CFS', 0, N'LCL/LCL-CFS/CFS', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (94, 62, N'cat-lai-kho-1', 0, N'CAT LAI KHO 1', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (95, 62, N'hai-phong-viet-nam', 0, N'HAI PHONG , VIETNAM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (96, 62, N'ho-chi-minh-port-viet-nam', 0, N'HO CHI MINH PORT, VIETNAM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (97, 62, N'ho-chi-minh-viet-nam', 0, N'HOCHIMINH CITY, VIET NAM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (98, 62, N'quy-nhon-viet-nam', 0, N'QUINHON, VIETNAM', NULL, 0)
INSERT [dbo].[Lookups] ([Id], [Type], [Code], [Order], [Title], [App], [Deleted]) VALUES (99, 63, N'Company', 0, N'Company', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Lookups] OFF
SET IDENTITY_INSERT [dbo].[OrderGenCodes] ON 

INSERT [dbo].[OrderGenCodes] ([Id], [OrderPrefix], [CurrentDate], [Begin], [CurrentNumber], [End], [Deleted]) VALUES (1, N'CL', CAST(N'2018-07-29T00:00:00.0000000+07:00' AS DateTimeOffset), 0, 1, 999, 0)
INSERT [dbo].[OrderGenCodes] ([Id], [OrderPrefix], [CurrentDate], [Begin], [CurrentNumber], [End], [Deleted]) VALUES (2, N'CT', CAST(N'2018-07-29T00:00:00.0000000+07:00' AS DateTimeOffset), 0, 1, 999, 0)
INSERT [dbo].[OrderGenCodes] ([Id], [OrderPrefix], [CurrentDate], [Begin], [CurrentNumber], [End], [Deleted]) VALUES (3, N'CS', CAST(N'2018-07-29T00:00:00.0000000+07:00' AS DateTimeOffset), 0, 2, 999, 0)
INSERT [dbo].[OrderGenCodes] ([Id], [OrderPrefix], [CurrentDate], [Begin], [CurrentNumber], [End], [Deleted]) VALUES (4, N'FLF', CAST(N'2018-07-29T00:00:00.0000000+07:00' AS DateTimeOffset), 0, 1, 999, 0)
SET IDENTITY_INSERT [dbo].[OrderGenCodes] OFF
SET IDENTITY_INSERT [dbo].[Ports] ON 

INSERT [dbo].[Ports] ([Id], [PortCode], [PortName], [NationalityId], [ZoneId], [LocalZone], [ModeId], [UpdateName], [UpdateAt], [CreatedAt], [CreatorId], [Deleted]) VALUES (1, N'EVN', N'Quận 9', 65, 55, N'Vietnam', 44, NULL, NULL, CAST(N'2018-07-29T09:36:55.0000000+07:00' AS DateTimeOffset), 1, 0)
SET IDENTITY_INSERT [dbo].[Ports] OFF
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'Admin', N'Quản trị', 1, N'AccessAdminPanel;ManageFalconUsers;ManageExaminationProcedure;ManageMessageTemplates;ManageSettings;ManageActivityLog;ManageSystemLog;ManageMessageQueue;ManageMaintenance;ManageNews;ManageHospital;ManageFeedback;ManageRole;ManageLookup;ManageRoom;ManageShift;ManageProduct;ManageMasterItem;ManageMap;ManageFeedback;ManageUserHospital;ManageReserved;ManageEmployee;ManageCalendarException;ManageCategory;ManageOrder;ManageSensorType;ManageDevice;ManageDeviceSeri;ManageCalendar;ManageFact;ManageAction;ManageActionFact;ManageFactSensor;ManageProvince;ManageGateway;ManageNewsFeed;ManageMessage;ManageQuestion;ManageTopic;ManageContact;ManageWaitingRegister;ManageSubscription;ManageSupplier;ManageWarehouse;ManageGrowingZone;ManageBreed;ManageCustomer')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'Employee', N'Nhân viên', 1, N'')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'Manager', N'Quản lý Cấp cao', 1, N'AccessAdminPanel;ManageCategory;ManageProduct;ManageOrder;ManageNewsFeed;ManageNews;ManageTopic;ManageContact;ManageEmployee')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'Operator', N'Vận hành hệ thống', 1, N'AccessAdminPanel')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'ProducingManager', N'Quản lý Sản xuất', 1, N'')
INSERT [dbo].[z_Role] ([SystemName], [Display], [Active], [Permissons]) VALUES (N'ProducingStaff', N'Nhân viên Sản xuất', 1, N'AccessAdminPanel')
SET IDENTITY_INSERT [dbo].[z_Setting] ON 

INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (1, N'securitysettings.encryptionkey', N'3815111477144342')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (2, N'securitysettings.uniquetoken', N'True')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (3, N'securitysettings.tokenlifetime', N'1440')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (4, N'securitysettings.cookielifetime', N'8544')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (5, N'systemsettings.cachelong', N'1440')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (6, N'systemsettings.cachenormal', N'90')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (7, N'systemsettings.cacheshort', N'5')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (8, N'systemsettings.domain', N'http://localhost:63198/')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (9, N'emailsettings.emailwelcometemplate', N'<p><span style="font-size:medium;"data-mce-mark="1"><strong>Ch&agrave;o mừng {@*userName}&nbsp;<span style="color:inherit;font-family:inherit;" data-mce-mark="1">tham gia Vino</span></strong></span></p><p>&nbsp;</p><p>Cảm ơn bạn đ&atilde; đăng k&yacute; t&agrave;i khoản tr&ecirc;n Vino.&nbsp;</p><p>Mật khẩu của bạn l&agrave;{@*password}</p><p>Th&acirc;n mến,</p><p><strong style="font-size:medium;"> BQT & nbsp; Vino</strong></p>')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (10, N'emailsettings.emailwelcometitle', N'Chào mừng thành viên của Vino')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (11, N'emailsettings.emailresetpasswordtemplate', N'<p>Dear <strong>{@*userName}</strong> !</p>
<p><br />Theo y&ecirc;u cầu của bạn, mật khẩu đăng nhập tr&ecirc;n <span style="color: #0000ff;">Vino</span> đ&atilde; được cấp mới. Chi tiết t&agrave;i khoản của bạn hiện tại như sau:</p>
<p>T&agrave;i khoản đăng nhập: {@*userName}</p>
<p>T&ecirc;n hiển thị: {@*displayName}</p><p>&nbsp;</p>
<p>Th&acirc;n mến,</p>
<p><span style="font-size: medium;"><strong>BQT Vino</strong></span></p>')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (12, N'emailsettings.emailresetpasswordtitle', N'Thông báo v/v đặt lại mật khẩu trên Vino')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (13, N'mediasettings.targetresize', N'100')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (14, N'metadatasettings.lastupdatedlookup', N'')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (15, N'metadatasettings.uploadingfolder', N'Uploads')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (16, N'metadatasettings.photosizepercent', N'5')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (17, N'metadatasettings.photomaxwidth', N'1024')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (18, N'metadatasettings.resizemode', N'ByMaxWidth')
INSERT [dbo].[z_Setting] ([Id], [Name], [Value]) VALUES (19, N'metadatasettings.numberofdaygetnewslatest', N'7')
SET IDENTITY_INSERT [dbo].[z_Setting] OFF
SET IDENTITY_INSERT [dbo].[z_User] ON 

INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (1, N'Admin', N'', NULL, N'78BC67A2623D728AFD1CD3E93311C4081CBF8392', N'OQV3IzUM', 1, N'Admin', 0)
INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (2, N'manager', N'', NULL, N'0056CA02F251A8A337BCAA95251A246AFC3D44EE', N'6SLYbKpH', 1, N'Manager', 0)
INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (3, N'operator', N'', NULL, N'1740C23FAFF57FA74B542780E9D9FA0731602BDC', N'UVUI9j9L', 1, N'Operator', 0)
INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (4, N'employee', N'', NULL, N'A4C7680EE577B2646FB972DF669ABB1CE7B6F205', N'XWuJRiyA', 1, N'Employee', 0)
INSERT [dbo].[z_User] ([Id], [UserName], [DisplayName], [AvatarUrl], [Password], [Salt], [Active], [Roles], [Deleted]) VALUES (5, N'user1', N'', NULL, N'3E5D66204BA4F67D14DF95AD55764436824AB950', N'KktT0W9l', 1, N'ProducingStaff', 0)
SET IDENTITY_INSERT [dbo].[z_User] OFF
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Carriers_CarrierId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.CrmContacts_OpicId] FOREIGN KEY([OpicId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.CrmContacts_OpicId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Ports_DestinationId] FOREIGN KEY([DestinationId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Ports_DestinationId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Ports_OriginPortId] FOREIGN KEY([OriginPortId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Ports_OriginPortId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.Ports_TransitPortId] FOREIGN KEY([TransitPortId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.Ports_TransitPortId]
GO
ALTER TABLE [dbo].[AirExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[AirExps] CHECK CONSTRAINT [FK_dbo.AirExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Carriers_AirlineId] FOREIGN KEY([AirlineId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Carriers_AirlineId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Ports_AodId] FOREIGN KEY([AodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Ports_AodId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Ports_AolId] FOREIGN KEY([AolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Ports_AolId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.Ports_DeliveryId] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.Ports_DeliveryId]
GO
ALTER TABLE [dbo].[AirImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AirImps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[AirImps] CHECK CONSTRAINT [FK_dbo.AirImps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[Carriers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Carriers_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carriers] CHECK CONSTRAINT [FK_dbo.Carriers_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[CrmContacts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmContacts_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CrmContacts] CHECK CONSTRAINT [FK_dbo.CrmContacts_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[CrmCustomers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmCustomers_dbo.CrmContacts_ContactId] FOREIGN KEY([ContactId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CrmCustomers] CHECK CONSTRAINT [FK_dbo.CrmCustomers_dbo.CrmContacts_ContactId]
GO
ALTER TABLE [dbo].[CrmCustomers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmCustomers_dbo.Lookups_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Lookups] ([Id])
GO
ALTER TABLE [dbo].[CrmCustomers] CHECK CONSTRAINT [FK_dbo.CrmCustomers_dbo.Lookups_CategoryId]
GO
ALTER TABLE [dbo].[CrmCustomers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmCustomers_dbo.Lookups_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Lookups] ([Id])
GO
ALTER TABLE [dbo].[CrmCustomers] CHECK CONSTRAINT [FK_dbo.CrmCustomers_dbo.Lookups_LocationId]
GO
ALTER TABLE [dbo].[CrmCustomers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CrmCustomers_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[CrmCustomers] CHECK CONSTRAINT [FK_dbo.CrmCustomers_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[Districts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Districts_dbo.Provinces_ProvinceId] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Provinces] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Districts] CHECK CONSTRAINT [FK_dbo.Districts_dbo.Provinces_ProvinceId]
GO
ALTER TABLE [dbo].[EmployeeDatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmployeeDatas_dbo.Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeDatas] CHECK CONSTRAINT [FK_dbo.EmployeeDatas_dbo.Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.Districts_DistrictId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.ImageRecords_ImageRecordId] FOREIGN KEY([ImageRecordId])
REFERENCES [dbo].[ImageRecords] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.ImageRecords_ImageRecordId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.Provinces_ProvinceId] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Provinces] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.Provinces_ProvinceId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.z_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.z_User_UserId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.Carriers_SlinesId] FOREIGN KEY([SlinesId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.Carriers_SlinesId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.Ports_PodId] FOREIGN KEY([PodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.Ports_PodId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.Ports_PolId] FOREIGN KEY([PolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.Ports_PolId]
GO
ALTER TABLE [dbo].[FclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[FclExps] CHECK CONSTRAINT [FK_dbo.FclExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Carriers_SlinesId] FOREIGN KEY([SlinesId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Carriers_SlinesId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Ports_DeliveryId] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Ports_DeliveryId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Ports_PodId] FOREIGN KEY([PodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Ports_PodId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.Ports_PolId] FOREIGN KEY([PolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.Ports_PolId]
GO
ALTER TABLE [dbo].[FclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FclImps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[FclImps] CHECK CONSTRAINT [FK_dbo.FclImps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_ConsigneeId] FOREIGN KEY([ConsigneeId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_ConsigneeId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_DeliveryOfGoodsId] FOREIGN KEY([DeliveryOfGoodsId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_DeliveryOfGoodsId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_NotifyPartyId] FOREIGN KEY([NotifyPartyId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_NotifyPartyId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_ShipperId] FOREIGN KEY([ShipperId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.CrmCustomers_ShipperId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.FclExps_FclExpId] FOREIGN KEY([FclExpId])
REFERENCES [dbo].[FclExps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.FclExps_FclExpId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_FinalDestinationId] FOREIGN KEY([FinalDestinationId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_FinalDestinationId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PlaceOfDeliveryId] FOREIGN KEY([PlaceOfDeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PlaceOfDeliveryId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PlaceOfReceiptId] FOREIGN KEY([PlaceOfReceiptId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PlaceOfReceiptId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PortOfDischargeId] FOREIGN KEY([PortOfDischargeId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PortOfDischargeId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PortOfLoaingId] FOREIGN KEY([PortOfLoaingId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_PortOfLoaingId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_TranshipmentPortId] FOREIGN KEY([TranshipmentPortId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.Ports_TranshipmentPortId]
GO
ALTER TABLE [dbo].[HblFclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblFclExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[HblFclExps] CHECK CONSTRAINT [FK_dbo.HblFclExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_ConsigneeId] FOREIGN KEY([ConsigneeId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_ConsigneeId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_DeliveryOfGoodsId] FOREIGN KEY([DeliveryOfGoodsId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_DeliveryOfGoodsId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_NotifyPartyId] FOREIGN KEY([NotifyPartyId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_NotifyPartyId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_ShipperId] FOREIGN KEY([ShipperId])
REFERENCES [dbo].[CrmCustomers] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.CrmCustomers_ShipperId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.LclExps_LclExpId] FOREIGN KEY([LclExpId])
REFERENCES [dbo].[LclExps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.LclExps_LclExpId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_FinalDestinationId] FOREIGN KEY([FinalDestinationId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_FinalDestinationId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PlaceOfDeliveryId] FOREIGN KEY([PlaceOfDeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PlaceOfDeliveryId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PlaceOfReceiptId] FOREIGN KEY([PlaceOfReceiptId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PlaceOfReceiptId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PortOfDischargeId] FOREIGN KEY([PortOfDischargeId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PortOfDischargeId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PortOfLoaingId] FOREIGN KEY([PortOfLoaingId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_PortOfLoaingId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_TranshipmentPortId] FOREIGN KEY([TranshipmentPortId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.Ports_TranshipmentPortId]
GO
ALTER TABLE [dbo].[HblLclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HblLclExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[HblLclExps] CHECK CONSTRAINT [FK_dbo.HblLclExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.Carriers_CoLoaderId] FOREIGN KEY([CoLoaderId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.Carriers_CoLoaderId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.Ports_PodId] FOREIGN KEY([PodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.Ports_PodId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.Ports_PolId] FOREIGN KEY([PolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.Ports_PolId]
GO
ALTER TABLE [dbo].[LclExps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclExps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[LclExps] CHECK CONSTRAINT [FK_dbo.LclExps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Carriers_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Carriers_AgentId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Carriers_SlinesId] FOREIGN KEY([SlinesId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Carriers_SlinesId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.CrmContacts_OpIcId] FOREIGN KEY([OpIcId])
REFERENCES [dbo].[CrmContacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.CrmContacts_OpIcId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Ports_DeliveryId] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Ports_DeliveryId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Ports_PodId] FOREIGN KEY([PodId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Ports_PodId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.Ports_PolId] FOREIGN KEY([PolId])
REFERENCES [dbo].[Ports] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.Ports_PolId]
GO
ALTER TABLE [dbo].[LclImps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LclImps_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
GO
ALTER TABLE [dbo].[LclImps] CHECK CONSTRAINT [FK_dbo.LclImps_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[Ports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Ports_dbo.z_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ports] CHECK CONSTRAINT [FK_dbo.Ports_dbo.z_User_CreatorId]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Topics_dbo.ImageRecords_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[ImageRecords] ([Id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_dbo.Topics_dbo.ImageRecords_ImageId]
GO
ALTER TABLE [dbo].[z_UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.z_UserClaim_dbo.z_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[z_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[z_UserClaim] CHECK CONSTRAINT [FK_dbo.z_UserClaim_dbo.z_User_UserId]
GO
