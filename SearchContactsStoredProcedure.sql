USE [ContactBookDB]
GO

CREATE PROCEDURE [dbo].[SearchContactsSP]
(
	@UserInput varchar(30)
)
AS
BEGIN
    DECLARE @query    nvarchar(1000)
 
    SET @query = 'SELECT * FROM Contacts e'
    SET @query = @query + ' WHERE 1=1'
 
    IF @UserInput != ''
        SET @query = @query + ' AND FirstName LIKE ''' + @UserInput + '%'''
        SET @query = @query + ' OR LastName LIKE ''' + @UserInput + '%'''
		SET @query = @query + ' OR MobilePhone LIKE ''' + @UserInput + '%'''
        SET @query = @query + ' OR HomePhone LIKE ''' + @UserInput + '%'''
        SET @query = @query + ' OR WorkPhone LIKE ''' + @UserInput + '%'''
        SET @query = @query + ' OR WorkAddress LIKE ''' + @UserInput + '%'''
        SET @query = @query + ' OR HomeAddress LIKE ''' + @UserInput + '%'''
        SET @query = @query + ' OR OtherAddress LIKE ''' + @UserInput + '%'''

    EXEC (@query)
END