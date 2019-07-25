namespace LambdaSLAPI.AlexaAPI
{
    using System;

    // see https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/dialog-interface-reference#delegate
    public static class AlexaConstants
    {
        public const String DialogDelegate = "Dialog.Delegate";

        public const String DialogElicitSlot = "Dialog.ElicitSlot";

        public const String DialogConfirmSlot = "Dialog.ConfirmSlot";

        public const String DialogConfirmIntent = "Dialog.ConfirmIntent";

        public const String DialogCompleted = "COMPLETED";

        public const String DialogStarted = "STARTED";

        public const String DialogInProgress = "IN_PROGRESS";

        public const String CancelIntent = "AMAZON.CancelIntent";

        public const String HelpIntent = "AMAZON.HelpIntent";

        public const String StopIntent = "AMAZON.StopIntent";

        public const String StartOverIntent = "AMAZON.StartOverIntent";

        public const String LaunchRequest = "LaunchRequest";

        public const String IntentRequest = "IntentRequest";

        public const String SessionEndedRequest = "SessionEndedRequest";

        public const String NoIntent = "AMAZON.NoIntent";

        public const String YesIntent = "AMAZON.YesIntent";

        public const String RepeatIntent = "AMAZON.RepeatIntent";

        public const String PauseIntent = "AMAZON.PauseIntent";

        public const String PreviousIntent = "AMAZON.PreviousIntent";

        public const String NextIntent = "AMAZON.NextIntent";

        public const String SSMLSpeech = "SSML";

        public const String PlainText = "PlainText";

        public const String AlexaVersion = "1.0";
    }
}