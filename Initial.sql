CREATE TABLE IF NOT EXISTS creditor (
	creditor_id int AUTO_INCREMENT NOT NULL UNIQUE,
	name varchar(255) NOT NULL,
	balance float NOT NULL,
	identity_number varchar(14) NOT NULL UNIQUE,
	password varchar(255) NOT NULL,
	email varchar(255) NOT NULL,
	PRIMARY KEY (creditor_id)
);

CREATE TABLE IF NOT EXISTS debtor (
	id_debtor int AUTO_INCREMENT NOT NULL UNIQUE,
	name varchar(255) NOT NULL,
	identity_number varchar(14),
	PRIMARY KEY (id_debtor)
);

CREATE TABLE IF NOT EXISTS loan (
	loan_id int AUTO_INCREMENT NOT NULL UNIQUE,
	total_value float NOT NULL,
	loan_value float NOT NULL,
	payment_status int NOT NULL,
	creditor_id int NOT NULL,
	debtor_id int NOT NULL,
	due_data datetime NOT NULL,
	registration_date datetime NOT NULL,
	interest float NOT NULL,
	PRIMARY KEY (loan_id)
);

CREATE TABLE IF NOT EXISTS payment_status (
	id_status int AUTO_INCREMENT NOT NULL UNIQUE,
	id_name varchar(255) NOT NULL,
	PRIMARY KEY (id_status)
);

CREATE TABLE IF NOT EXISTS installment (
	installment_order int NOT NULL,
	value float NOT NULL,
	loan_id int NOT NULL,
	due_date datetime NOT NULL,
	status_payment int NOT NULL,
	interest float NOT NULL,
	PRIMARY KEY (installment_order)
);



ALTER TABLE loan ADD CONSTRAINT loan_fk2 FOREIGN KEY (payment_status) REFERENCES payment_status(id_status);

ALTER TABLE loan ADD CONSTRAINT loan_fk3 FOREIGN KEY (creditor_id) REFERENCES creditor(creditor_id);

ALTER TABLE loan ADD CONSTRAINT loan_fk4 FOREIGN KEY (debtor_id) REFERENCES debtor(id_debtor);

ALTER TABLE installment ADD CONSTRAINT installments_fk2 FOREIGN KEY (loan_id) REFERENCES loan(loan_id);

ALTER TABLE installment ADD CONSTRAINT installments_fk4 FOREIGN KEY (status_payment) REFERENCES payment_status(id_status);