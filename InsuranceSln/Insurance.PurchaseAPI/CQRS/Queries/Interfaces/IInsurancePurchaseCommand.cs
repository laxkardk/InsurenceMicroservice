using Insurance.PurchaseAPI.Models;

namespace Insurance.PurchaseAPI.CQRS.Queries.Interfaces
{
    public interface IInsurancePurchaseCommand
    {
        Task<InsuranceProductCommandModel> PlaceOrder(InsuranceProductCommandModel model);
        Task<InsuranceProductCommandModel> UpdateOrder(InsuranceProductCommandModel model);
        Task<bool> DeleteOrder(int CustomerPolicyId);
        Task<bool> ConfirmOrder(int CustomerPolicyId);
    }
}
