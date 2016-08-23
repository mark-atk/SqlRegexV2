DROP FUNCTION [dbo].[fnRegExGroups]
GO

DROP FUNCTION [dbo].[fnRegExMatches]
GO

DROP FUNCTION [dbo].[fnRegExGroup]
GO

DROP FUNCTION [dbo].[fnRegExMatch]
GO

IF  EXISTS (SELECT * FROM sys.assemblies asms WHERE asms.name = N'SqlRegexV2')
    DROP ASSEMBLY [SqlRegexV2]
GO


CREATE ASSEMBLY [SqlRegexV2] FROM 'C:\Users\mark.atkinson\Documents\Visual Studio 2015\Projects\SqlRegexV2\SqlRegexV2\bin\Debug\SqlRegexV2.dll'
GO

CREATE FUNCTION [dbo].[fnRegExGroups](@input [nvarchar](max), @pattern [nvarchar](max), @name [nvarchar](max))
RETURNS  TABLE (
	[idx] [int] NULL,
	[match] [nvarchar](max) NULL
) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SqlRegexV2].[SqlRegexV2.UserDefinedFunctions].[RegexGroups]
GO

CREATE FUNCTION [dbo].[fnRegExMatches](@input [nvarchar](max), @pattern [nvarchar](max))
RETURNS  TABLE (
	[idx] [int] NULL,
	[match] [nvarchar](max) NULL
) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SqlRegexV2].[SqlRegexV2.UserDefinedFunctions].[RegexMatches]
GO

CREATE FUNCTION [dbo].[fnRegExGroup](@input [nvarchar](max), @pattern [nvarchar](max), @name [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SqlRegexV2].[SqlRegexV2.UserDefinedFunctions].[RegexGroup]
GO


CREATE FUNCTION [dbo].[fnRegExMatch](@input [nvarchar](max), @pattern [nvarchar](max))
RETURNS [bit] WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SqlRegexV2].[SqlRegexV2.UserDefinedFunctions].[RegexMatch]
GO
