/*  
Create tables (script file must be flagged as Embedded Resource)
*/

CREATE TABLE [dbo].[MyCompanyClient](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[SiteId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_MyCompanyClient] PRIMARY KEY CLUSTERED 
  (
	[ClientId] ASC
  )
)
GO