using AutoMapper;
using CottonTouch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {

            // Hotel --> HotelViewModel
            Mapper.CreateMap<Hotel, HotelViewModel>()
                .ForMember(g => g.HotelID, map => map.MapFrom(vm => vm.HotelID))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(g => g.Telephone, map => map.MapFrom(vm => vm.Telephone))
                .ForMember(g => g.mobile, map => map.MapFrom(vm => vm.mobile))
                .ForMember(g => g.Notes, map => map.MapFrom(vm => vm.Notes))
                .ForMember(g => g.Logo, map => map.MapFrom(vm => vm.Logo))
                .ForMember(g => g.Website, map => map.MapFrom(vm => vm.Website));


         

            // Item --> ItemViewModel
            Mapper.CreateMap<Item, ItemViewModel>()
                .ForMember(g => g.ItemID, map => map.MapFrom(vm => vm.ItemID))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Quantity, map => map.MapFrom(vm => vm.Quantity))
                .ForMember(g => g.UnitPrice, map => map.MapFrom(vm => vm.UnitPrice));

            // User --> UserViewModel
            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(g => g.UserID, map => map.MapFrom(vm => vm.UserID))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Password, map => map.MapFrom(vm => vm.Password))
                .ForMember(g => g.RoleID, map => map.MapFrom(vm => vm.RoleID))
                .ForMember(g => g.isAuthunticated, map => map.MapFrom(vm => vm.isAuthunticated))
                .ForMember(g => g.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(g => g.CreatedDate, map => map.MapFrom(vm => vm.CreatedDate))
                .ForMember(g => g.Role, map => map.MapFrom(vm => vm.Role));


            // ServiceRequest  --> ServiceRequestViewModel
            Mapper.CreateMap<ServiceRequest, ServiceRequestViewModel>()
                .ForMember(g => g.ServiceRequestID, map => map.MapFrom(vm => vm.ServiceRequestID))
                .ForMember(g => g.HotelID, map => map.MapFrom(vm => vm.HotelID))
                .ForMember(g => g.TotalSentItems, map => map.MapFrom(vm => vm.TotalSentItems))
                .ForMember(g => g.TotalRecievedItems, map => map.MapFrom(vm => vm.TotalRecievedItems))
                .ForMember(g => g.ClientSignature, map => map.MapFrom(vm => vm.ClientSignature))
                .ForMember(g => g.LaundrySignature, map => map.MapFrom(vm => vm.LaundrySignature))
                .ForMember(g => g.DocumentAttached, map => map.MapFrom(vm => vm.DocumentAttached))
                .ForMember(g => g.TotalPrice, map => map.MapFrom(vm => vm.TotalPrice))
                .ForMember(g => g.Date, map => map.MapFrom(vm => vm.Date))
                .ForMember(g => g.Hotel, map => map.MapFrom(vm => vm.Hotel));

            // ItemServiceRequest  --> ItemServiceRequestViewModel
            Mapper.CreateMap<ItemServiceRequest, ItemServiceRequestViewModel>()
                .ForMember(g => g.ItemServiceRequestID, map => map.MapFrom(vm => vm.ItemServiceRequestID))
                .ForMember(g => g.ServiceRequestID, map => map.MapFrom(vm => vm.ServiceRequestID))
                .ForMember(g => g.ItemID, map => map.MapFrom(vm => vm.ItemID))
                .ForMember(g => g.QtnSentToLaundry, map => map.MapFrom(vm => vm.QtnSentToLaundry))
                .ForMember(g => g.QtnRecievedAtLaundry, map => map.MapFrom(vm => vm.QtnRecievedAtLaundry))
                .ForMember(g => g.UnitPrice, map => map.MapFrom(vm => vm.UnitPrice))
                .ForMember(g => g.VATPercent, map => map.MapFrom(vm => vm.VATPercent))
                .ForMember(g => g.VATAmount, map => map.MapFrom(vm => vm.VATAmount))
                .ForMember(g => g.DiscAmount, map => map.MapFrom(vm => vm.DiscAmount))
                .ForMember(g => g.NetAmount, map => map.MapFrom(vm => vm.NetAmount))
                .ForMember(g => g.Date, map => map.MapFrom(vm => vm.Date))
                .ForMember(g => g.Item, map => map.MapFrom(vm => vm.Item))
                .ForMember(g => g.ServiceRequest, map => map.MapFrom(vm => vm.ServiceRequest));

            // Role  --> RoleViewModel
            Mapper.CreateMap<Role, RoleViewModel>()
                .ForMember(g => g.RoleID, map => map.MapFrom(vm => vm.RoleID))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description));

            // Invoice  --> InvoiceViewModel
            Mapper.CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(g => g.InvoiceID, map => map.MapFrom(vm => vm.InvoiceID))
                .ForMember(g => g.HotelID, map => map.MapFrom(vm => vm.HotelID))
                .ForMember(g => g.ServiceRequestID, map => map.MapFrom(vm => vm.ServiceRequestID))
                .ForMember(g => g.TotalDiscount, map => map.MapFrom(vm => vm.TotalDiscount))
                .ForMember(g => g.TotalNetAmount, map => map.MapFrom(vm => vm.TotalNetAmount))
                .ForMember(g => g.CarriageNet, map => map.MapFrom(vm => vm.CarriageNet))
                .ForMember(g => g.TotalTaxAmount, map => map.MapFrom(vm => vm.TotalTaxAmount))
                .ForMember(g => g.InvoiceTotal, map => map.MapFrom(vm => vm.InvoiceTotal))
                .ForMember(g => g.InvoiceNumber, map => map.MapFrom(vm => vm.InvoiceNumber))
                .ForMember(g => g.Date, map => map.MapFrom(vm => vm.Date))
                .ForMember(g => g.Hotel, map => map.MapFrom(vm => vm.Hotel))
                .ForMember(g => g.ServiceRequest, map => map.MapFrom(vm => vm.ServiceRequest));

            // HotelItemPrice  --> HotelItemPriceViewModel
            Mapper.CreateMap<HotelItemPrice, HotelItemPriceViewModel>()
                .ForMember(g => g.HIPID, map => map.MapFrom(vm => vm.HIPID))
                .ForMember(g => g.HotelID, map => map.MapFrom(vm => vm.HotelID))
                .ForMember(g => g.ItemID, map => map.MapFrom(vm => vm.ItemID))
                .ForMember(g => g.PricePerItem, map => map.MapFrom(vm => vm.PricePerItem))
                .ForMember(g => g.Hotel, map => map.MapFrom(vm => vm.Hotel))
                .ForMember(g => g.Item, map => map.MapFrom(vm => vm.Item));
        }
    }
}