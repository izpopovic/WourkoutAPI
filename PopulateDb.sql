use  WorkoutDb
go

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
insert into ExerciseCategory 
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

select * from ExerciseCategory
select * from Exercises
select * from WorkoutDifficulties order by Id
select * from WorkoutTypes


--//////////////////////////////////////////////////////////
---WORKOUT--------------------------------------------------
--//////////////////////////////////////////////////////////
---PREDEFINED WORKOUTS--------------------------------------
select * from Workouts
select * from WorkoutTypes
select * from WorkoutDifficulties

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
'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
45,1,1,1,1)
--2. strength, easy, day 2
insert into Workouts
values ('Back & Biceps',
'Have a 10 minute warmup before you begin your workout. Stretch at the end.',
45,1,1,1,2)
--3. strength, easy, day 3
insert into Workouts
values ('Legs & Shoulders',
'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
45,1,1,1,3)
--4. strength, intermediate, day 1
insert into Workouts
values ('Chest & Triceps',
'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
45,1,2,1,1)
--5. strength, intermediate, day 2
insert into Workouts
values ('Chest & Triceps',
'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
45,1,2,1,2)
--6. strength, intermediate, day 3
insert into Workouts
values ('Chest & Triceps',
'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
45,1,2,1,3)
--7. strength, advanced, day 1
insert into Workouts
values ('Chest & Triceps',
'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
45,1,3,1,1)
--8. strength, advanced, day 2
insert into Workouts
values ('Chest & Triceps',
'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
45,1,3,1,2)
--9. strength, advanced, day 3
insert into Workouts
values ('Chest & Triceps',
'Designed to hit each muscle group with the big compound exercises once per week. Have a 10 minute warmup before you begin your workout.',
45,1,3,1,3)







--//////////////////////////////////////////////////////////
---EXERCISE WORKOUT-----------------------------------------
--//////////////////////////////////////////////////////////
---PREDEFINED WORKOUTS--------------------------------------
select * from ExerciseWorkout
select * from Exercises where CategoryId = 4
select * from ExerciseCategory

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

-- DAY 1
-- DAY 2
-- DAY 3

--ADVANCED WORKOUT
-- DAY 1
-- DAY 2
-- DAY 3


--CARDIO
--BEGGINER WORKOUT
--INTERMEDIATE WORKOUT
--ADVANCED WORKOUT



--//////////////////////////////////////////////////////////
---USER-----------------------------------------------------
--//////////////////////////////////////////////////////////
---TEST USER------------------------------------------------

select * from ExerciseWorkout

select * from Workouts

