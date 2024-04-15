Create Database Railway_Reservation
use Railway_Reservation

--1:- User Section...

-- Trains_Detail Table
Create Table Trains_Detail(Train_id numeric(5) primary key,Train_name varchar(70),Depart_city varchar(80),
Arrival_city varchar(90))
-- Insert value in Trains_Detail
Insert into Trains_Detail values
(22435,'VANDE BHARAT EXP','PRAYAGRAJ JN.','NEW DELHI',1),
(11062,'JYG LTT EXP','PRAYAGRAJ JN.',' LOKMANYATILAK T',1),
(22436,'VANDE BHARAT EXP','NEW DELHI','KANPUR CENTRAL',1),
(12655,'NAVJEEVAN EXP','SURAT','VIJAYAWADA JN',1),
(12576,'HYB FEST SPL','GOMATI NAGAR','HYDERABAD DECAN',1)
--Adding Column
alter table Trains_Detail add Active_or_Not Bit Not Null Default 1
--Data
select * from Trains_Detail


-- Book_Tickets table
Create Table Book_Ticket(Ticket_no numeric(4) Primary key, Train_id numeric(5) foreign key references Trains_Detail(Train_id),Name varchar(70),
Age numeric(5),Gender varchar(10), Class varchar(7))
--Data
select * from Book_Ticket



-- Cancel_Ticket table
Create Table Cancel_Ticket(Cancelation_Id numeric(5) Primary key,Ticket_no numeric(5) , Train_id numeric(5) foreign key references Trains_Detail(Train_id),
Status varchar(10))
--Data
select * from Cancel_Ticket


-- Seat_Availability table
Create Table Seat_Availability(Seat_id numeric(3) Identity ,Train_id numeric(5) foreign key references Trains_Detail(Train_id),[1AC] numeric(5),[2AC] numeric(5),[3AC] numeric(5))
-- Insert value in Seat_Availability
Insert into Seat_Availability values
(22435, 40, 30, 30),
(11062, 25, 15, 40),
(22436, 60, 22, 38), 
(12655, 18, 32, 40),
(12576, 23, 27, 20)
--Data
select * from Seat_Availability


--User Details Table
create table user_details(
[user-id] int not null primary key,
[user-name] varchar(20),
password varchar(20),
)
select * from user_details


-- Fair_S table
Create Table Fair_S(SequenceNO int identity,Train_id numeric(5) foreign key references Trains_Detail(Train_id),
[1AC] numeric(5),[2AC] numeric(5),[3AC] numeric(5))
--Insert value in Fair_S
insert into Fair_S values(22435, 4000, 2000, 1300),
(11062, 2500, 1200, 900),(22436, 6000, 2800, 1340), 
(12655, 1800, 970, 490),(12576, 2300, 1120, 509)
--Data
select * from Fair_S




--2:- Admin Section

-- Admin Detail Table
create table Admin_Detail(Admin_userName varchar(20), Admin_pass varchar(30), Admin_id int Primary key)
Insert into Admin_Detail Values('Shantanu2408','@Shantanu2408singh','1034315')


--Remove Seat Procedure
Create or alter proc setseatavl(@@trainid int, @class varchar(20))
as
begin
if @class='1Ac'
update Seat_Availability set [1AC] =[1AC]-1 where Train_id=@trainid
else if @class ='2Ac'
update Seat_Availability set [2AC] =[2AC]-1 where Train_id=@trainid
else if @class ='3Ac'
update Seat_Availability set [3AC] =[3AC]-1 where Train_id=@trainid
end
drop proc setseatavl


--Add Seat Procedure
Create or alter proc setseatavl1(@trainid int,@class varchar(20))
as
begin
if @class ='1Ac'
update Seat_Availability set [1AC] =[1AC]+1 where Train_id=@trainid
else if @class ='2Ac'
update Seat_Availability set [2AC] =[2AC]+1 where Train_id=@trainid
else if @class ='3Ac'
update Seat_Availability set [3AC] =[3AC]+1 where Train_id=@trainid
end


--Add Seat Details Procedure
Create or alter proc Add_Seat(@trainid numeric(5),@fac int, @sac int, @tac int)
as
begin
insert into  Seat_Availability (Train_id,[1AC],[2AC],[3AC]) 
values(@trainid,@fac,@sac,@tac)
end


--Add Fair Details procedure
Create or alter proc Add_Fair(@train_id numeric(5),@facf int, @sacf int, @tacf int)
as
begin
insert into  Fair_S values(@train_id,@facf,@sacf,@tacf)
end
