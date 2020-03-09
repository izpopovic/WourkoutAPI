use  WorkoutDb
go

--//////////////////////////////////////////////////////////
---EXERCISE CATEGORY----------------------------------------
--//////////////////////////////////////////////////////////
------------------------------------------------------------
insert into ExerciseCategories
values ('Chest',0)
insert into ExerciseCategories 
values ('Triceps',0)
insert into ExerciseCategories 
values ('Biceps',0)
insert into ExerciseCategories 
values ('Shoulders',0)
insert into ExerciseCategories 
values ('Abs',0)
insert into ExerciseCategories 
values ('Back',0)
insert into ExerciseCategories 
values ('Upper legs',0)
insert into ExerciseCategories 
values ('Glutes',0)
insert into ExerciseCategories 
values ('Lower legs',0)
insert into ExerciseCategories 
values ('Cardio',0)
insert into ExerciseCategories 
values ('Compound exercises',0)

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---CHEST----------------------------------------------------

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
values ('Push-up',1,0)
insert into Exercises
values ('Flat dumbell flye',1,0)
insert into Exercises
values ('Incline dumbell flye',1,0)
insert into Exercises
values ('Decline dumbell flye',1,0)
insert into Exercises
values ('Cable cross-over',1,0)
insert into Exercises
values ('Seated chest press',1,0)
-- In case you want to reset id count
--DBCC CHECKIDENT ('Exercises', RESEED, 0);
--GO

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---TRICEPS----------------------------------------------------

insert into Exercises
values('Close-grip bench press',2,0)
insert into Exercises
values('Rope triceps pushdown',2,0)
insert into Exercises
values('Triceps dips',2,0)
insert into Exercises
values('Overhead triceps extension',2,0)
insert into Exercises
values('Skullcrushers',2,0)
insert into Exercises
values('Diamond press-up',2,0)
insert into Exercises
values('Triceps dip machine',2,0)
insert into Exercises
values('Seated overhead dumbbell extension',2,0)
insert into Exercises
values('Cable push-down',2,0)
insert into Exercises
values('Tricep dumbbell kickback',2,0)
insert into Exercises
values('Bench dips',2,0)

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---BICEPS----------------------------------------------------

insert into Exercises
values('Standing dumbbell curl',3,0)
insert into Exercises
values('Incline dumbbell curl',3,0)
insert into Exercises
values('Decline dumbbell curl',3,0)
insert into Exercises
values('Hammer curl',3,0)
insert into Exercises
values('Standing barbell curl',3,0)
insert into Exercises
values('Concentration curl',3,0)
insert into Exercises
values('Zottman curl',3,0)
insert into Exercises
values('Cable rope hammer curl',3,0)
insert into Exercises
values('Overhead cable curl',3,0)
insert into Exercises
values('EZ-bar preacher curl',3,0)
insert into Exercises
values('EZ-bar curl',3,0)

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---SHOULDERS------------------------------------------------

insert into Exercises
values('Barbell push press',4,0)
insert into Exercises
values('Seated dumbbell shoulder press',4,0)
insert into Exercises
values('Arnold press',4,0)
insert into Exercises
values('Lateral raise',4,0)
insert into Exercises
values('Seated bent over rear delt raise',4,0)
insert into Exercises
values('Barbell overhead press',4,0)
insert into Exercises
values('Reverse pec deck fly',4,0)
insert into Exercises
values('Barbell front raise',4,0)
insert into Exercises
values('Dumbbell shrug',4,0)
insert into Exercises
values('Barbell shrug',4,0)
insert into Exercises
values('One-arm cable lateral raise',4,0)
insert into Exercises
values('Cable front raise',4,0)
insert into Exercises
values('Face pull',4,0)
insert into Exercises
values('EZ bar upright row',4,0)
insert into Exercises
values('Upright cable row',4,0)
insert into Exercises
values('Dumbbell incline row',4,0)
insert into Exercises
values('Seated overhead barbell press',4,0)

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---ABS------------------------------------------------------

insert into Exercises
values('Barbell floor wiper',5,0)
insert into Exercises
values('Medicine ball slam',5,0)
insert into Exercises
values('Side jacknife',5,0)
insert into Exercises
values('Dragon flag',5,0)
insert into Exercises
values('Cable woodchopper',5,0)
insert into Exercises
values('Sit-up',5,0)
insert into Exercises
values('Hanging leg raise',5,0)
insert into Exercises
values('Lying leg raise',5,0)
insert into Exercises
values('Jacknife sit-up',5,0)
insert into Exercises
values('Leg pull-in',5,0)
insert into Exercises
values('Toe touchers',5,0)
insert into Exercises
values('Crunches',5,0)
insert into Exercises
values('Reverse crunch',5,0)
insert into Exercises
values('Plank',5,0)
insert into Exercises
values('Dead bug',5,0)
insert into Exercises
values('Dumbbell side bend',5,0)
insert into Exercises
values('Side plank',5,0)
insert into Exercises
values('Alternating toe reach',5,0)
insert into Exercises
values('Windshield wipers',5,0)
insert into Exercises
values('Russian twist',5,0)
insert into Exercises
values('Side-to-side crunch',5,0)
insert into Exercises
values('Cross mountain climbers',5,0)
insert into Exercises
values('Bicycle crunch',5,0)
insert into Exercises
values('Mountain climbers',5,0)
insert into Exercises
values('Side plank with reach through',5,0)
insert into Exercises
values('Side plank dip',5,0)
insert into Exercises
values('Plank with hip dip',5,0)
insert into Exercises
values('Abs roll-out',5,0)
insert into Exercises
values('V-sit',5,0)
insert into Exercises
values('Tuck and crunch',5,0)

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---BACK-----------------------------------------------------

insert into Exercises
values('Deadlift',6,0)

insert into Exercises
values('Kettlebell swings',6,0)
insert into Exercises
values('Pull-up',6,0)
insert into Exercises
values('Chin-up',6,0)
insert into Exercises
values('Dumbbell single arm row',6,0)
insert into Exercises
values('Chest supported dumbbell row',6,0)
insert into Exercises
values('Inverted row',6,0)
insert into Exercises
values('Lat pull-down',6,0)
insert into Exercises
values('Single-arm T-bar rows',6,0)
insert into Exercises
values('Standing T-bar row',6,0)
insert into Exercises
values('Barbell bent-over rows',6,0)
insert into Exercises
values('Underhand bent-over barbell row',6,0)
insert into Exercises
values('Seated cable row',6,0)
insert into Exercises
values('Wide-grip seated cable row',6,0)
insert into Exercises
values('Close-grip pull-down',6,0)
insert into Exercises
values('Scapular pull-ups',6,0)

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---UPPER LEGS(Quads and hamstrings)-------------------------

insert into Exercises
values('Back squat',7,0)
insert into Exercises
values('Front squat',7,0)
insert into Exercises
values('Machine squat',7,0)
insert into Exercises
values('Dumbbell squat',7,0)
insert into Exercises
values('Kettlebell pistol squat',7,0)
insert into Exercises
values('Hack squat',7,0)
insert into Exercises
values('Goblet squat',7,0)
insert into Exercises
values('Barbell side lunge',7,0)
insert into Exercises
values('Sumo deadlift',7,0)
insert into Exercises
values('Romanian deadlift',7,0)
insert into Exercises
values('Leg press',7,0)
insert into Exercises
values('Farmers walk',7,0)
insert into Exercises
values('Walking lunges',7,0)
insert into Exercises
values('Bulgarian split squat',7,0)
insert into Exercises
values('Dumbbell step-up',7,0)
insert into Exercises
values('Leg extension',7,0)
insert into Exercises
values('Seated leg curl',7,0)

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---GLUTEUS--------------------------------------------------

insert into Exercises
values('Clamshells',8,0)
insert into Exercises
values('Lateral stepping',8,0)
insert into Exercises
values('Barbell hip thrusts',8,0)
insert into Exercises
values('Hip thrusts with resistance band',8,0)
insert into Exercises
values('Standing kickbacks with resistance band',8,0)
insert into Exercises
values('Cable kickback',8,0)
insert into Exercises
values('Single-leg deadlift',8,0)
insert into Exercises
values('Single-leg hip thrusters',8,0)
insert into Exercises
values('Frog pumps',8,0)
insert into Exercises
values('Quadruped hip extension',8,0)
insert into Exercises
values('4-3-1 sumo dumbbell squat',8,0)
insert into Exercises
values('Cable standing hip abduction',8,0)
insert into Exercises
values('Goblet reverse lunge',8,0)
insert into Exercises
values('Hip extension',8,0)


--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---LOWER LEGS(Calfs)----------------------------------------

insert into Exercises
values ('Calf press',9,0)
insert into Exercises
values ('Standing calf raise',9,0)
insert into Exercises
values ('Seated calf raise',9,0)
insert into Exercises
values ('Single dumbbell calf raise',9,0)
insert into Exercises
values ('Box jump',9,0)
insert into Exercises
values ('Donkey calf raise',9,0)
insert into Exercises
values ('Single-leg calf raise',9,0)

--//////////////////////////////////////////////////////////
---EXERCISES------------------------------------------------
--//////////////////////////////////////////////////////////
---CARDIO---------------------------------------------------

insert into Exercises
values('Skaters',10,0)
insert into Exercises
values('Rollbacks',10,0)
insert into Exercises
values('Burpee',10,0)
insert into Exercises
values('Jump rope',10,0)
insert into Exercises
values('Vertical jacks',10,0)
insert into Exercises
values('Split squat jump',10,0)
insert into Exercises
values('Suicide sprints',10,0)
insert into Exercises
values('Jumping jacks',10,0)
insert into Exercises
values('Joggin in place',10,0)
insert into Exercises
values('Squat jumps',10,0)
insert into Exercises
values('Sprints',10,0)
insert into Exercises
values('Treadmill running',10,0)
insert into Exercises
values('Battle ropes',10,0)


--//////////////////////////////////////////////////////////
---WORKOUT--------------------------------------------------
--//////////////////////////////////////////////////////////
---WORKOUT DIFFICULTIES-------------------------------------

insert into WorkoutDifficulties
values('Beginner')
insert into WorkoutDifficulties
values('Intermediate')
insert into WorkoutDifficulties
values('Advanced')
insert into WorkoutDifficulties
values('Custom')

--//////////////////////////////////////////////////////////
---WORKOUT--------------------------------------------------
--//////////////////////////////////////////////////////////
---WORKOUT TYPE---------------------------------------------

insert into WorkoutTypes
values('Strength',0)
insert into WorkoutTypes
values('Cardio',0)
insert into WorkoutTypes
values('Custom',0)

select * from ExerciseCategories
select * from Exercises where Exercises.CategoryId = 10
select * from WorkoutDifficulties order by Id
select * from WorkoutTypes


--//////////////////////////////////////////////////////////
---WORKOUT--------------------------------------------------
--//////////////////////////////////////////////////////////
---PREDEFINED WORKOUTS--------------------------------------
select * from Workouts
select * from WorkoutTypes
select * from WorkoutDifficulties
select * from ExerciseWorkout

--delete from ExerciseWorkout

--DBCC CHECKIDENT ('ExerciseWorkout', RESEED, 0);
--GO

--delete from Workouts

--DBCC CHECKIDENT ('Workouts', RESEED, 0);
--GO


	  
    --  ,[Name]
    --  ,[Description]
    --  ,[Duration]
    --  ,[WorkoutTypeId]
    --  ,[WorkoutDifficultyId]
    --  ,[IsPredefined]
    --  ,[WorkoutDay]
--insert into Workouts
--values ('Chest & Triceps',
--'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
--45,1,1,1,1)

--Workouts
--1. strength, easy, day 1
insert into Workouts
values ('Chest & Triceps',
'Have a 10 minute warmup before you begin your workout.',
45,1,1,1,1)
--2. strength, easy, day 2
insert into Workouts
values ('Back & Biceps',
'Have a 10 minute warmup before you begin your workout. Stretch at the end.',
45,1,1,1,2)
--3. strength, easy, day 3
insert into Workouts
values ('Legs & Shoulders',
'Have a 10 minute warmup before you begin your workout. Stretch at the end.',
45,1,1,1,3)






--4. strength, intermediate, day 1
insert into Workouts
values ('Chest & Biceps', '', 45,1,2,1,1)
--5. strength, intermediate, day 2
insert into Workouts
values ('Legs',
'Warm up legs with some cardio before workout!',
45,1,2,1,2)
--6. strength, intermediate, day 3
insert into Workouts
values ('Back',
'',
45,1,2,1,3)
--6. strength, intermediate, day 4
insert into Workouts
values ('Shoulders & Triceps',
'',
45,1,2,1,4)

--advanced day 1
insert into Workouts
values ('Chest',
'Stretch your chest muscles before workout!',
60,1,3,1,1)
--advanced day 2
insert into Workouts
values ('Back',
'',
60,1,3,1,2)
--advanced day 3
insert into Workouts
values ('Shoulders',
'',
60,1,3,1,3)
--advanced day 4
insert into Workouts
values ('Arms',
'',
60,1,3,1,4)
--advanced day 5
insert into Workouts
values ('Legs',
'',
60,1,3,1,5)

----------------------------------------
select * from Workouts
--CARDIO EXAMPLE
-- EASY
insert into Workouts values ('Cardio', 'Stretch before workout!', 25, 2, 1, 1, 1)


--INTERMEDIATE
insert into Workouts values ('Cardio', 'Take 2 minute rest after each exercise', 40, 2, 2, 1, 1)


--ADVANCED

insert into Workouts values ('Cardio', 'Take 1 minute rest after each exercise', 60, 2, 3, 1, 1)



----7. strength, advanced, day 1
--insert into Workouts
--values ('Chest & Triceps',
--'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
--45,1,3,1,1)
----8. strength, advanced, day 2
--insert into Workouts
--values ('Chest & Triceps',
--'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
--45,1,3,1,2)
----9. strength, advanced, day 3
--insert into Workouts
--values ('Chest & Triceps',
--'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
--45,1,3,1,3)







--//////////////////////////////////////////////////////////
---EXERCISE WORKOUT-----------------------------------------
--//////////////////////////////////////////////////////////
---PREDEFINED WORKOUTS--------------------------------------
select * from ExerciseWorkout
select * from Exercises where CategoryId = 4


-- EASY WORKOUT
-- DAY 1
-- Chest
insert into ExerciseWorkout
values(2,1,'10','3','Have your bench at a 30 degree angle.',0)
insert into ExerciseWorkout
values(4,1,'10','4','',0)

-- Triceps
insert into ExerciseWorkout
values(15,1,'Failure','3','Make sure you lean forward to focus the work on your lower chest. Use assisted dip machine if you cannot do bodyweight.',0)
insert into ExerciseWorkout
values(17,1,'10','4','Light weights only, focus on form.',0)

-- DAY 2
-- Back
insert into ExerciseWorkout
values(90,2,'10','4','',0)
insert into ExerciseWorkout
values(95,2,'12','3','',0)
insert into ExerciseWorkout
values(87,2,'10','3','',0)

-- Biceps
insert into ExerciseWorkout
values(28,2,'10','3','You can also use EZ bar.',0)

-- DAY 3
-- Legs
insert into ExerciseWorkout
values(110,3,'12,10,10,8','4','First do 12 reps with lower weight, then increase the weight and lower the number of reps.',0)
insert into ExerciseWorkout
values(115,3,'12','3','',0)
insert into ExerciseWorkout
values(116,3,'12','3','',0)

-- Shoulders

insert into ExerciseWorkout
values(40,3,'8-10','4','',0)
insert into ExerciseWorkout
values(38,3,'10','3','',0)

--INTERMEDIATE WORKOUT
-- DAY 1 CHEST & BICEPS ID 4
--reps sets descript weight id
insert into ExerciseWorkout
values(1,4,'8-10',4,'Form over weight!',0)
insert into ExerciseWorkout
values(5,4,'8',3,'Have your bench at 30 degree angle!',0)
insert into ExerciseWorkout
values(10,4,'8',3,'',0)

insert into ExerciseWorkout
values(29,4,'8',3,'',0)
insert into ExerciseWorkout
values(25,4,'8',3,'',0)
insert into ExerciseWorkout
values(30,4,'8',3,'',0)

-- DAY 2 LEGS id 5
-------------
insert into ExerciseWorkout
values(108,5,'8',3,'',0)
insert into ExerciseWorkout
values(115,5,'8',3,'',0)

insert into ExerciseWorkout
values(99,5,'10',3,'Keep your back straight!',0)
insert into ExerciseWorkout
values(109,5,'8',3,'Never fully extend your knees!',0)
insert into ExerciseWorkout
values(114,5,'8',3,'',0)

insert into ExerciseWorkout
values(131,5,'15,12,10,8',4,'',0)

-- DAY 3 BACk id 6

insert into ExerciseWorkout
values(85,6,'Warm up',2,'',0)
insert into ExerciseWorkout
values(93,6,'8',3,'',0)
insert into ExerciseWorkout
values(95,6,'8',3,'',0)
insert into ExerciseWorkout
values(87,6,'8',3,'Each hand 8 repetitions per set!',0)
insert into ExerciseWorkout
values(83,6,'8',3,'Chest out, back straight, chin up!',0)

-- DAY 4 SHOULDERS AND TRICEPS id 7

insert into ExerciseWorkout
values(37,7,'Warm up',2,'',0)
insert into ExerciseWorkout
values(36,7,'8',3,'',0)
insert into ExerciseWorkout
values(47,7,'8',3,'Lift to eye level height!',0)
insert into ExerciseWorkout
values(40,7,'8',3,'',0)

insert into ExerciseWorkout
values(22,7,'8',3,'',0)
insert into ExerciseWorkout
values(14,7,'8',3,'',0)
insert into ExerciseWorkout
values(17,7,'8',3,'',0)


--ADVANCED WORKOUT
-- DAY 1 id 8 Chest
insert into ExerciseWorkout
values(5,8,'8-10',4,'',0)
insert into ExerciseWorkout
values(10,8,'12',4,'',0)
insert into ExerciseWorkout
values(1,8,'8-10',4,'',0)
insert into ExerciseWorkout
values(12,8,'15',3,'',0)
insert into ExerciseWorkout
values(7,8,'10',3,'',0)
insert into ExerciseWorkout
values(8,8,'15-20',3,'',0)

-- DAY 2 id 9
insert into ExerciseWorkout
values(85,9,'10',4,'',0)
insert into ExerciseWorkout
values(93,9,'8',4,'',0)
insert into ExerciseWorkout
values(97,9,'12',4,'',0)
insert into ExerciseWorkout
values(91,9,'8',4,'Both hands once per set!',0)
insert into ExerciseWorkout
values(88,9,'10',3,'',0)
insert into ExerciseWorkout
values(90,9,'15',3,'',0)

-- DAY 3 id 10
insert into ExerciseWorkout
values(39,10,'12-15',4,'',0)
insert into ExerciseWorkout
values(37,10,'10-12',4,'',0)
insert into ExerciseWorkout
values(41,10,'8-10',4,'',0)
insert into ExerciseWorkout
values(47,10,'8-10',4,'',0)
insert into ExerciseWorkout
values(44,10,'15',3,'',0)
insert into ExerciseWorkout
values(48,10,'12-15',4,'',0)


-- DAY 4 id 11

insert into ExerciseWorkout
values(28,11,'10-12',4,'',0)
insert into ExerciseWorkout
values(34,11,'10-12',3,'',0)
insert into ExerciseWorkout
values(35,11,'12-15',4,'',0)
insert into ExerciseWorkout
values(26,11,'10',4,'',0)
insert into ExerciseWorkout
values(15,11,'15',4,'',0)
insert into ExerciseWorkout
values(17,11,'15-20',4,'',0)
insert into ExerciseWorkout
values(18,11,'12-15',3,'',0)

-- DAY 5 id 12
insert into ExerciseWorkout
values(109,12,'10-12',4,'',0)
insert into ExerciseWorkout
values(99,12,'8-10',4,'',0)
insert into ExerciseWorkout
values(114,12,'15',3,'',0)
insert into ExerciseWorkout
values(104,12,'10',4,'',0)
insert into ExerciseWorkout
values(115,12,'15',3,'',0)
insert into ExerciseWorkout
values(131,12,'20',3,'',0)

select * from Workouts
select * from ExerciseCategories
select * from ExerciseWorkout
select * from Exercises where Exercises.CategoryId = 7 or Exercises.CategoryId = 8 or Exercises.CategoryId = 9
--------------------------------------------------------------------------
--CARDIO
--BEGGINER WORKOUT
--DAY 1 id 13
insert into ExerciseWorkout
values(148,13,'15 min',1,'',0)
insert into ExerciseWorkout
values(145,13,'5 min',1,'',0)
insert into ExerciseWorkout
values(140,13,'5 min',1,'',0)

--INTERMEDIATE WORKOUT
--Day 2 id 14
insert into ExerciseWorkout
values(148,14,'20 min',1,'',0)
insert into ExerciseWorkout
values(145,14,'5 min',1,'',0)
insert into ExerciseWorkout
values(140,14,'5 min',1,'',0)
insert into ExerciseWorkout
values(143,14,'5 min',1,'',0)
insert into ExerciseWorkout
values(144,14,'5 min',1,'',0)
--ADVANCED WORKOUT 15
insert into ExerciseWorkout
values(148,15,'15 min',1,'',0)
insert into ExerciseWorkout
values(146,15,'5 min',1,'',0)
insert into ExerciseWorkout
values(140,15,'10 min',1,'',0)
insert into ExerciseWorkout
values(147,15,'5 min',1,'',0)
insert into ExerciseWorkout
values(139,15,'5 min',1,'',0)
insert into ExerciseWorkout
values(149,15,'10 min',1,'',0)
insert into ExerciseWorkout
values(142,15,'5 min',1,'',0)
insert into ExerciseWorkout
values(144,15,'5 min',1,'',0)




--//////////////////////////////////////////////////////////
---USER-----------------------------------------------------
--//////////////////////////////////////////////////////////
---TEST USER------------------------------------------------

select * from ExerciseWorkout

select * from Workouts

