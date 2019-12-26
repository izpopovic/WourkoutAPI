--//////////////////////////////////////////////////////////
---EXERCISE CATEGORY----------------------------------------
--//////////////////////////////////////////////////////////
------------------------------------------------------------
insert into ExerciseCategory 
values ('Chest',0)
insert into ExerciseCategory 
values ('Triceps',0)
insert into ExerciseCategory 
values ('Biceps',0)
insert into ExerciseCategory 
values ('Shoulders',0)
insert into ExerciseCategory 
values ('Abs',0)
insert into ExerciseCategory 
values ('Back',0)
insert into ExerciseCategory 
values ('Upper legs',0)
insert into ExerciseCategory 
values ('Glutes',0)
insert into ExerciseCategory 
values ('Lower legs',0)
insert into ExerciseCategory 
values ('Cardio',0)

select * from ExerciseCategory

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
------------------------------------------------------------
insert into Exercises
values ('Flat barbell bench press',1,0)
insert into Exercises
values ('Incline barbell bench press',1,0)
insert into Exercises
values ('Decline barbell bench press',1,0)
insert into Exercises
values ('Flat dumbbell bench press',1,0)
insert into Exercises
values ('Incline dumbbell bench press',1,0)
insert into Exercises
values ('Decline dumbbell bench press',1,0)
insert into Exercises
values ('Dips for chest',1,0)
insert into Exercises
values ('Push ups',1,0)
insert into Exercises
values ('Flat dumbell flye',1,0)
insert into Exercises
values ('Incline dumbell flye',1,0)
insert into Exercises
values ('Decline dumbell flye',1,0)

select * from Exercises
select * from ExerciseCategory
-- In case you want to reset id count
--DBCC CHECKIDENT ('Exercises', RESEED, 0);
--GO