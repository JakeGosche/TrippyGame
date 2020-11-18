using UnityEngine;
using System.Collections;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections.Generic;
using static Enums;

public class DialogueRepository : MonoBehaviour
{


    public List<ConversationObject> GetDialogue(Speaker speakerId, int conversationId)
    {
        List<ConversationObject> conversationList = new List<ConversationObject>();
        switch (speakerId)
        {
            case Speaker.Eyre:
                switch (conversationId)
                {
                    //First speak to Eyre
                    case 0:
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "Good morning, Rosalyn." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "Today is February 12, 2103." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "We are currently 134 light years from Kepler-186f." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "You have been revived to provide me with mission critical assistance." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "What has happened?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "I am unable to revive the other crew." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "There is an error in the Neuro-Network that I cannot diagnose." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "I require your help to discover the cause." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "What do you need me to do?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "You must proceed to the Neural Network Array." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "But first you will need to leave this Cryochamber." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "Mid-flight access to the rest of the ship requires Class A access." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "You will need to request the access code from a crew member in Cryosleep." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "How do I do that?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "Each Cryopod has a Neuro Interface with which you can communicate with those in Cryosleep." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "Please acquire the Class A access code so we may continue." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Eyre, Message = "The corruption to the Neuro Network is expanding." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Okay, okay." });
                        break;

                }
                break;
            case Speaker.Shapley:
                switch (conversationId)
                {
                    //Corrupted speak
                    case 0:
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Shapley, Message = "The song isn't right." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "I don't hear a song." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Shapley, Message = "Listen. It's a remix. You need to find the original composition." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Where can I find it?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Shapley, Message = "It's remixing all the songs. We can't dance to this. The records are under the floorboards." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "I don't understand." });
                        break;

                }
                break;
            case Speaker.Chong:
                switch (conversationId)
                {
                    //Corrupted speak
                    case 0:
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Chong, Message = "I can't find the pieces." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Can I ask you a question?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Chong, Message = "I need to find the pieces before he gets here." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Who?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Chong, Message = "I don't have time for this. It's almost three." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Time for what?" });
                        break;

                }
                break;
            case Speaker.Mitropoulos:
                switch (conversationId)
                {
                    //Corrupted speak
                    case 0:
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Mitropoulos, Message = "No." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Sorry?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Mitropoulos, Message = "No." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "I haven't asked you anything yet." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Mitropoulos, Message = "No." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Ok." });
                        break;

                }
                break;
            case Speaker.York:
                switch (conversationId)
                {
                    //Corrupted speak
                    case 0:
                        conversationList.Add(new ConversationObject { Speaker = Speaker.York, Message = "Sanji is my favorite." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Who is Sanji?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.York, Message = "Obviously, I like Luffy too. But Sanji is just the best Straw Hat." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "I'm not sure I am following." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.York, Message = "Who is your favourite?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "I don't know." });
                        break;

                }
                break;
            case Speaker.Cassidy:
                switch (conversationId)
                {
                    //Corrupted speak
                    case 0:
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Cassidy, Message = "Oh god, I need to get off." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Get off what?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Cassidy, Message = "This coaster! How much longer til it's over?" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "I'm not really sure." });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Cassidy, Message = "Is that another loop? I can't do another loop!" });
                        conversationList.Add(new ConversationObject { Speaker = Speaker.Rosalyn, Message = "Hold your hands above your head." });
                        break;

                }
                break;
        }
        return conversationList;
    }
}
