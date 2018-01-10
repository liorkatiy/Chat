namespace Mail
{
    /// <summary>
    /// Contains Information But The Sender Email
    /// </summary>
    public struct MailInfo
    {
        public string Smtp { get; private set; }
        public string UserName { get; private set; }
        public System.Security.SecureString Password { get; private set; }
        public int Port { get; private set; }
        public bool SSL { get; private set; }

        public MailInfo(string smtp, int port, bool ssl, string username, string password)
        {
            Smtp = smtp;
            UserName = username;
            Port = port;
            SSL = ssl;
            Password = new System.Security.SecureString();
            for (int i = 0; i < password.Length; i++)
            {
                Password.AppendChar(password[i]);
            }
        }
    }
}
