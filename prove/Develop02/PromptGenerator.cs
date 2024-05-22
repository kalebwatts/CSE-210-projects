using System;

public class PromptGenerator
{
    private static readonly string[] prompts = {
        "What is something funny that happened today?",
        "What is one thing you want to be remembered for?",
        "What would you do if you were a millionaire?",
        "If you could travel anywhere in the world, where would you go?",
        "Who is someone you want to meet someday?",
        "What is your favorite memory from childhood?",
        "What are you most grateful for today?",
        "Describe a place where you feel most at peace.",
        "What is a challenge you overcame recently?",
        "What is your favorite book and why?",
        "If you could have dinner with anyone, living or dead, who would it be?",
        "What is a skill you'd like to learn and why?",
        "What was the best part of your day?",
        "What is one thing you love about yourself?",
        "If you could change one thing about the world, what would it be?",
        "Describe a dream you had recently.",
        "What are your top three goals for the next year?",
        "What is something new you tried recently?",
        "What do you value most in a friendship?",
        "Describe your perfect day.",
        "What is your favorite hobby and why?",
        "What is one lesson life has taught you?",
        "Who is someone who has influenced your life in a positive way?",
        "What is your favorite holiday and why?",
        "If you could live in any time period, which would it be and why?",
        "What is a favorite family tradition?",
        "What is something you are looking forward to?",
        "What is the best advice you've ever received?",
        "What is a cause you are passionate about?",
        "What is one thing you would like to achieve this year?",
        "What is a favorite quote or saying that inspires you?",
        "Describe a moment when you felt truly happy.",
        "What is a recent accomplishment you are proud of?",
        "What is one thing you would tell your younger self?",
        "What does success mean to you?",
        "What is your favorite way to relax?",
        "Describe a person you admire and why.",
        "What is your favorite movie and why?",
        "What is one thing you can't live without?",
        "What is your favorite way to spend a weekend?"
    };

    public string GeneratePrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}

