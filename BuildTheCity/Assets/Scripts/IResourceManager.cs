﻿public interface IResourceManager
{
    float MoneyCalculationInterval { get; set; }
    int StartMoneyAmount { get; set; }

    void AddMoney(int amount);
    void CalculateTownIncome();
    bool CanIBuyIt(int amount);
    bool SpendMoney(int amount);
}