create or alter procedure CalculateSumAndMedian as
begin
	declare @total_sum bigint
	declare @median decimal(10,8)
	declare @row_count int

	select @total_sum = cast(sum(cast(IntNumber as bigint)) as bigint) from Informations
	select @row_count = count(*) from Informations
	
	if @row_count % 2 = 1
		begin
			select top(1) @median = DoubleNumber
			from (
				select DoubleNumber, 
					   ROW_NUMBER() over (order by DoubleNumber) as RowNumber
				from Informations
			) as Temp
			where Temp.RowNumber = (@row_count+1)/2
		end
	else
		begin
			select top(1) @median = AVG(DoubleNumber)
			from (
				select DoubleNumber,
					   ROW_NUMBER() over (order by DoubleNumber) as RowNumber
				from Informations
			) as Temp
			where Temp.RowNumber in (@row_count/2,(@row_count/2)+1)
		end

	select @median as Median,
		   @total_sum as IntSum
end

exec CalculateMedian