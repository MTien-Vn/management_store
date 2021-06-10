CREATE OR REPLACE FUNCTION public.func_insert_quantity_invoice_item()
	RETURNS int4
	LANGUAGE plpgsql
AS $function$
	declare
		counter int;
	BEGIN
		counter = 1;
		for counter in 1..500 loop
			update  invoice_item set quantity = counter where invoice_item.quantity is null;
			if counter < 100 then
				counter = counter + 1;
			else 
				counter = 1;
			end if;
		end loop;
		return counter;
	END;
$function$
;
