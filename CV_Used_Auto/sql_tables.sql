CREATE TABLE Users
(
user_id varchar(25) NOT NULL,
user_password varchar(50) NOT NULL,
address varchar(25),
city varchar(15),
state char(2),
zip_code varchar(5),
PRIMARY KEY(user_id)
);

CREATE TABLE Inventory
(
make varchar(15) NOT NULL,
model varchar(30) NOT NULL,
color char(10),
trans char(10),
drive varchar(3),
miles int,
price varchar(8),
car_year int,
vin varchar(17) NOT NULL,
PRIMARY KEY(vin)
);
