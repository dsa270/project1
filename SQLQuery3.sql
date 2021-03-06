USE [JECRC_Ritika]
GO
/****** Object:  Table [dbo].[user_login]    Script Date: 07/04/2019 09:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user_login](
	[user_id] [int] NULL,
	[user_code] [varchar](255) NULL,
	[user_name] [varchar](255) NULL,
	[user_email] [varchar](255) NULL,
	[user_email2] [varchar](255) NULL,
	[user_phone] [varchar](50) NULL,
	[user_phone2] [varchar](50) NULL,
	[user_status] [varchar](255) NULL,
	[user_remark] [varchar](255) NULL,
	[user_password] [varchar](255) NULL,
	[user_type] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[supplier]    Script Date: 07/04/2019 09:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[supplier](
	[supplier_id] [numeric](15, 0) NULL,
	[supplier_name] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRODUCT_Sub_CATEGORY]    Script Date: 07/04/2019 09:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCT_Sub_CATEGORY](
	[product_Sub_category_id] [bigint] IDENTITY(1,1) NOT NULL,
	[product_Sub_category_code] [varchar](50) NULL,
	[product_category_code] [varchar](50) NULL,
	[product_Sub_category_name] [varchar](50) NULL,
	[product_Sub_category_details] [varchar](50) NULL,
	[product_Sub_category_status] [varchar](50) NULL,
	[product_Sub_category_start_date] [varchar](50) NULL,
	[product_Sub_category_end_date] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRODUCT_CATEGORY]    Script Date: 07/04/2019 09:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCT_CATEGORY](
	[product_category_id] [bigint] IDENTITY(1,1) NOT NULL,
	[product_category_code] [varchar](50) NULL,
	[product_category_name] [varchar](50) NULL,
	[product_category_details] [varchar](50) NULL,
	[product_category_status] [varchar](50) NULL,
	[product_category_start_date] [varchar](50) NULL,
	[product_category_end_date] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product]    Script Date: 07/04/2019 09:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product](
	[product_code] [varchar](50) NULL,
	[product_name] [varchar](50) NULL,
	[product_price] [varchar](50) NULL,
	[product_offer] [varchar](50) NULL,
	[product_highlights] [varchar](50) NULL,
	[product_description] [varchar](50) NULL,
	[product_warranty] [varchar](50) NULL,
	[product_start_date] [varchar](50) NULL,
	[product_end_date] [varchar](50) NULL,
	[product_status] [varchar](50) NULL,
	[product_id] [varchar](50) NOT NULL,
	[product_category_code] [varchar](50) NULL,
	[product_Sub_category_code] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[pcategory]    Script Date: 07/04/2019 09:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[pcategory](
	[product_cat_id] [bigint] IDENTITY(1,1) NOT NULL,
	[product_cat_code] [varchar](50) NOT NULL,
	[product_cat_name] [varchar](50) NULL,
	[product_cat_desc] [varchar](250) NULL,
	[product_cat_sname] [varchar](50) NULL,
	[product_cat_status] [varchar](50) NULL,
 CONSTRAINT [PK_pcategory] PRIMARY KEY CLUSTERED 
(
	[product_cat_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[order1]    Script Date: 07/04/2019 09:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[order1](
	[order_id] [numeric](30, 0) NULL,
	[supplier_id] [numeric](15, 0) NULL,
	[order_date] [varchar](40) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
