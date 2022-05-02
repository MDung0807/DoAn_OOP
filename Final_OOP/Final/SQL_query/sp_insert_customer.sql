USE [SMS]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_customer]    Script Date: 11/18/2021 3:44:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE Proc [dbo].[sp_insert_customer] (@id int, @name nvarchar(100))
as
	insert into Customer(customer_id,customer_name) values (@id,@name)
GO

