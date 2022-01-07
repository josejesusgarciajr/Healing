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

INSERT INTO Note
VALUES
('Monday, January 3, 2022 7:00 PM', 0, 1, 5, 90, 95, 'Felt good. We ran at Santa Monica. We were able to get on the pier! We walked around. Saw the Lights, and even ate hot dogs which was the highlight of the night :)');


INSERT INTO Note
VALUES
('Wednesday, January 5, 2022 12:55 PM', 2, 3, 30, 45, 25, 'Woke up feeling alright. The heavyness is not so bad. Baby steps. You are going to make it a good day.');

INSERT INTO Note
VALUES
('Wednesday, January 6, 2022 10:10 AM', 2, 5, 65, 0, 0,
 'Had a bad dream about my boss getting upset with me. Woke up feeling extreemly anxious and the heavyness was horrible. Went back to sleep to have another bad dream. Woke up feeling a tiny bit better but I was still shoken from the first dream.');

INSERT INTO Note 
VALUES 
('Thursday, January 6, 2022 4:42 PM', 1, 2, 30, 35, 35,
  'I was feeling really heavy, but then after taking the pills, drinking a tumeric, and looking at the pictures from Hawaii I felt happier. I realized my girlfriend is mine. That she\'s the same girl from Hawaii. And she\'s Mine :)');
