using System;
namespace DesignPatterns.Behavioural.MementoEx
{
    public class Memento
    {
        // TODO: Aggiungi le proprietà necessarie per salvare lo stato dell'oggetto PhotoEditor
    }

    public class PhotoEditor
    {
        // TODO: Aggiungi le proprietà per rappresentare lo stato dell'immagine (ad esempio, dimensioni, colore, ecc.)

        // TODO: Implementa i metodi per eseguire le operazioni di modifica sull'immagine (ad esempio, ridimensionamento, cambio colore, ecc.)

        // TODO: Implementa il metodo SaveState() che crea un nuovo Memento e salva lo stato corrente dell'oggetto PhotoEditor

        // TODO: Implementa il metodo RestoreState(Memento memento) che ripristina lo stato dell'oggetto PhotoEditor utilizzando un Memento
    }

    public class History
    {
        // TODO: Implementa una struttura dati per memorizzare lo storico dei mementi (ad esempio, una lista o uno stack)

        // TODO: Implementa il metodo Push(Memento memento) per aggiungere un Memento allo storico

        // TODO: Implementa il metodo Pop() per rimuovere e restituire l'ultimo Memento aggiunto allo storico
    }
}

