USE [SMS]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_count_total]    Script Date: 11/18/2021 3:45:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create Function [dbo].[fn_count_total] (@id int)
returns int as
begin
	declare @total float
	select @total= CONVERT(float,SUM(price*CONVERT(float,quantity)))
	from LineItem
	where order_id=@id
	return @total
end
GO

