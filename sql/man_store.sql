-- public.customer definition

-- Drop table

-- DROP TABLE public.customer;

CREATE TABLE public.customer (
	customer_id bpchar(36) NOT NULL,
	customer_name varchar(100) NULL,
	dob date NULL,
	cumulative_point int4 NULL DEFAULT 0,
	email varchar(100) NULL,
	phone varchar(15) NOT NULL,
	address varchar(255) NULL,
	state int4 NOT NULL,
	customer_code bpchar(10) NULL,
	CONSTRAINT customer_pk PRIMARY KEY (customer_id)
);


-- public.discount_voucher definition

-- Drop table

-- DROP TABLE public.discount_voucher;

CREATE TABLE public.discount_voucher (
	discount_voucher_id bpchar(36) NOT NULL,
	discount_voucher_code varchar(10) NOT NULL,
	expired_date date NOT NULL,
	min_total_amount numeric(19) NULL,
	effective_date date NULL,
	discount_rate int4 NULL,
	max_discount numeric(19) NULL,
	CONSTRAINT discount_voucher_pk PRIMARY KEY (discount_voucher_id)
);


-- public.category definition

-- Drop table

-- DROP TABLE public.category;

CREATE TABLE public.category (
	category_id bpchar(36) NOT NULL,
	category_name varchar(255) NULL,
	category_code varchar NOT NULL,
	description text NULL,
	CONSTRAINT category_pk PRIMARY KEY (category_id),
	CONSTRAINT category_un UNIQUE (category_code)
);


-- public."group" definition

-- Drop table

-- DROP TABLE public."group";

CREATE TABLE public."group" (
	group_id bpchar(36) NOT NULL,
	group_name varchar(100) NOT NULL,
	base_salary float8 NOT NULL,
	CONSTRAINT group_employee_pk PRIMARY KEY (group_id)
);


-- public.vendor definition

-- Drop table

-- DROP TABLE public.vendor;

CREATE TABLE public.vendor (
	vendor_id bpchar(36) NOT NULL,
	vendor_code varchar(10) NOT NULL,
	vendor_name varchar NOT NULL,
	address varchar(255) NULL,
	phone_number varchar(15) NOT NULL,
	email varchar(100) NULL,
	tax_number varchar(15) NULL,
	state int2 NOT NULL,
	CONSTRAINT vendors_pk PRIMARY KEY (vendor_id),
	CONSTRAINT vendors_un UNIQUE (vendor_code, phone_number, tax_number)
);
CREATE INDEX vendors_vendor_code_idx ON public.vendor USING btree (vendor_code, phone_number);


-- public.employee definition

-- Drop table

-- DROP TABLE public.employee;

CREATE TABLE public.employee (
	employee_id bpchar(36) NOT NULL,
	employee_code varchar(5) NOT NULL,
	employee_name varchar(100) NOT NULL,
	dob date NULL,
	address varchar(255) NULL,
	phone_number varchar(15) NOT NULL,
	email varchar(100) NULL,
	gender int4 NULL,
	identify_number varchar(12) NOT NULL,
	shift int2 NULL,
	pass_word varchar(20) NULL,
	status int2 NULL,
	join_date date NOT NULL,
	group_id bpchar(36) NOT NULL,
	CONSTRAINT employee_pk PRIMARY KEY (employee_id),
	CONSTRAINT employee_un UNIQUE (employee_code, phone_number, identify_number),
	CONSTRAINT employee_fk FOREIGN KEY (group_id) REFERENCES "group"(group_id)
);
CREATE INDEX employee_employee_code_idx ON public.employee USING btree (employee_code, phone_number);


-- public.item definition

-- Drop table

-- DROP TABLE public.item;

CREATE TABLE public.item (
	item_id bpchar(36) NOT NULL,
	item_code varchar(10) NOT NULL,
	item_name varchar(255) NOT NULL,
	unit varchar(50) NULL,
	description text NULL,
	category_id bpchar(36) NOT NULL,
	state int2 NOT NULL,
	ave_imported_price float8 NOT NULL,
	rate_profit int2 NOT NULL,
	CONSTRAINT items_pk PRIMARY KEY (item_id),
	CONSTRAINT items_un UNIQUE (item_code),
	CONSTRAINT items_fk FOREIGN KEY (category_id) REFERENCES category(category_id)
);
CREATE INDEX items_item_code_idx ON public.item USING btree (item_code);


-- public."order" definition

-- Drop table

-- DROP TABLE public."order";

CREATE TABLE public."order" (
	order_id bpchar(36) NOT NULL,
	"date" date NULL,
	culmulative_point_used int4 NULL,
	employee_id bpchar(36) NULL,
	customer_id bpchar(36) NULL,
	discount_voucher_id varchar(36) NULL,
	CONSTRAINT order_pk PRIMARY KEY (order_id),
	CONSTRAINT order_un UNIQUE (discount_voucher_id),
	CONSTRAINT order_fk FOREIGN KEY (customer_id) REFERENCES customer(customer_id),
	CONSTRAINT order_fk_1 FOREIGN KEY (employee_id) REFERENCES employee(employee_id),
	CONSTRAINT order_fk_2 FOREIGN KEY (discount_voucher_id) REFERENCES discount_voucher(discount_voucher_id)
);


-- public.invoice definition

-- Drop table

-- DROP TABLE public.invoice;

CREATE TABLE public.invoice (
	invoice_id bpchar(36) NOT NULL,
	invoice_code varchar(25) NOT NULL,
	employee_id bpchar(36) NOT NULL,
	vendor_id bpchar(36) NOT NULL,
	"date" date NULL,
	CONSTRAINT invoice_pk PRIMARY KEY (invoice_id),
	CONSTRAINT invoice_fk FOREIGN KEY (employee_id) REFERENCES employee(employee_id),
	CONSTRAINT invoice_fk_vendor FOREIGN KEY (vendor_id) REFERENCES vendor(vendor_id)
);


-- public.item_order definition

-- Drop table

-- DROP TABLE public.item_order;

CREATE TABLE public.item_order (
	order_id bpchar(36) NOT NULL,
	item_id bpchar(36) NOT NULL,
	quantity int4 NULL,
	selling_price float8 NULL,
	CONSTRAINT imported_item_order_pk PRIMARY KEY (order_id, item_id),
	CONSTRAINT imported_item_order_fk FOREIGN KEY (order_id) REFERENCES "order"(order_id),
	CONSTRAINT item_order_fk FOREIGN KEY (item_id) REFERENCES item(item_id)
);


-- public.invoice_item definition

-- Drop table

-- DROP TABLE public.invoice_item;

CREATE TABLE public.invoice_item (
	invoice_id bpchar(36) NOT NULL,
	item_id bpchar(36) NOT NULL,
	quantity int4 NULL,
	imported_price float8 NOT NULL,
	CONSTRAINT invoice_item_pk PRIMARY KEY (invoice_id, item_id),
	CONSTRAINT invoice_line_fk FOREIGN KEY (item_id) REFERENCES item(item_id),
	CONSTRAINT invoice_line_fk_1 FOREIGN KEY (invoice_id) REFERENCES invoice(invoice_id)
);