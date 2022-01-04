CREATE DATABASE Healing;

CREATE TABLE Note(
    ID INT IDENTITY PRIMARY KEY,
    DateTimeStamp varchar(100),
    Anxiety FLOAT,
    Uneasyness FLOAT,
    Heavyness FLOAT,
    Happyness FLOAT,
    Excited FLOAT,
    Expression varchar(max)
);

INSERT INTO Note
VALUES('Saturday, January 1, 2022 4:13 PM', 5, 5, 70, 0, 0, 'I woke up Feeling like shit. I was scared. Im scared of going to sleep because I know the morning is always the hardest.'),
('Sunday, January 2, 2022 4:13 PM', 5, 5, 70, 0, 0, 'No Progress. Arguing is not helping. I need good days inorder to wake up feeling better. I keep having to say affirmations to fall back asleep after waking up. After a quick nap it does down a little bit.');


INSERT INTO Note
VALUES
('Sunday, January 2, 2022 6:25 PM', 2, 1, 10, 75, 95, 'I got a spark at work :) It felt good to feel excited'),
('Sunday, January 2, 2022 10:25 PM', 0, 1, 5, 95, 95, 'I had an amazing time with my girlfriend. It felt like before. We danced, we took pictures, we went for a walk. I was happy :)');
