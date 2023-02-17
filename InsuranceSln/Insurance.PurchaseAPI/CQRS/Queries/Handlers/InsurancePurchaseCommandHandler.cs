using Insurance.PurchaseAPI.CQRS.Queries.Interfaces;
using Insurance.PurchaseAPI.Database;
using Insurance.PurchaseAPI.Models;

namespace Insurance.PurchaseAPI.CQRS.Queries.Handlers
{
    public class InsurancePurchaseCommandHandler : IInsurancePurchaseCommand
    {
        AppDbContext _appDbContext;
        public InsurancePurchaseCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> ConfirmOrder(int CustomerPolicyId)
        {
            PurchaseInsuranceEntity policy = _appDbContext.PurchaseInsurance.Where(x => x.CustomerPolicyId == CustomerPolicyId).FirstOrDefault();
            policy.IsConfirm = true;
            _appDbContext.PurchaseInsurance.Update(policy);
            var result = await _appDbContext.SaveChangesAsync();
            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteOrder(int CustomerPolicyId)
        {
            PurchaseInsuranceEntity policy = _appDbContext.PurchaseInsurance.Where(x => x.CustomerPolicyId == CustomerPolicyId).FirstOrDefault();
            _appDbContext.PurchaseInsurance.Remove(policy);
            var result = await _appDbContext.SaveChangesAsync();
            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<InsuranceProductCommandModel> PlaceOrder(InsuranceProductCommandModel model)
        {
            try
            {
                var policy = new PurchaseInsuranceEntity
                {
                    CustomerPolicyId = model.CustomerPolicyId,
                    CustomerAddress = model.CustomerAddress,
                    Price = model.Price,
                    PaymentMethod = model.PaymentType,
                    Quantity = model.PolicyQuantity,
                    IsConfirm = model.IsConfirm,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = model.CreatedDate,
                    ModifiedBy = model.ModifiedBy,
                    ModifiedDate = model.ModifiedDate,
                };

                _appDbContext.PurchaseInsurance.Add(policy);
                await _appDbContext.SaveChangesAsync();

                model.CustomerPolicyId = policy.CustomerPolicyId;                
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return model;
        }

        public async Task<InsuranceProductCommandModel> UpdateOrder(InsuranceProductCommandModel model)
        {
            PurchaseInsuranceEntity? updpolicy = _appDbContext.PurchaseInsurance.Where(x => x.CustomerPolicyId == model.CustomerPolicyId).FirstOrDefault();
            if (updpolicy != null)
            {
                updpolicy.CustomerPolicyId = model.CustomerPolicyId;
                updpolicy.CustomerAddress = model.CustomerAddress;
                updpolicy.Price = model.Price;
                updpolicy.PaymentMethod = model.PaymentType;
                updpolicy.Quantity = model.PolicyQuantity;
                updpolicy.IsConfirm = model.IsConfirm;
                updpolicy.CreatedBy = model.CreatedBy;
                updpolicy.CreatedDate = model.CreatedDate;
                updpolicy.ModifiedBy = model.ModifiedBy;
                updpolicy.ModifiedDate = model.ModifiedDate;
                _appDbContext.PurchaseInsurance.Update(updpolicy);
                await _appDbContext.SaveChangesAsync();
                model.CustomerPolicyId = updpolicy.CustomerPolicyId;
                return model;
            }
            else
                return null;               
                
        }
    }
}
