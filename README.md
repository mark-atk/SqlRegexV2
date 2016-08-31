# Why

It is sometimes needed to have more matching possibilities in t-SQL than
PATINDEX and LIKE provide.

To be able to use it in SQL Server 2008R2 (Version 10.x), the project is for
.Net 2.0. Sorry.

# How

Just clone this repo and compile the solution. It was tested with VS2015
Professional. This will give you - among other things - an SQL file in your
build directory. This one can be directly executed in SQL Server Management
Studio *after you have switched to SQLCMD mode*. It will create a database
`rex` inside which the functions reside.

# Usage

This project defines five functions that can be used in SQL statements:

* bit RegexMatch
* nvarchar RegexGroup
* ( int, nvarchar ) RegexGroups
* ( int, nvarchar, nvarchar ) RegexGroups2
* ( int, nvarchar ) RegexMatches

