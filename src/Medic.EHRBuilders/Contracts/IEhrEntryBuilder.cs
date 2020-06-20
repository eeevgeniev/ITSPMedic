using Medic.EHR.Clinical;
using Medic.EHR.Clinical.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrEntryBuilder : IDisposable
    {
        IEhrEntryBuilder AddCodedValue(string originalText, string code, string codeSystem, string displayName);

        IEhrEntryBuilder AddIdentifierName(string identifierName);

        IEhrEntryBuilder AddInformationProvider(string rootName, string extension, string identifierName);

        IEhrEntryBuilder AddItem(Item item);

        Entry Build();

        IEhrEntryBuilder Clear();
    }
}