import {createRouter, createWebHashHistory} from "vue-router";
import HomePage from "@/home/HomePage.vue";
import LegalContractDetails from "@/legalcontracts/LegalContractDetails.vue";
import LegalContractsList from "@/legalcontracts/LegalContractsList.vue";
import UpdateContract from "@/legalcontracts/UpdateContract.vue";

export default createRouter({
    linkActiveClass: "active-link",
    history: createWebHashHistory(),
    routes: [
        {
            path: "/",
            name: "Home",
            component: HomePage,
        },
        {
            path: "/update/:id",
            name: "UpdateContracts",
            component: UpdateContract,
            props: true,
        },
        {
            path: "/details/:id",
            name: "ContractDetails",
            component: LegalContractDetails,
        },
        {
            path: "/list",
            name: "ListContracts",
            component: LegalContractsList,
        },
        {
            path: "/create",
            name: "CreateContracts",
            
            // We are leaving this as an example o fan alternative way to load a component
            component: () => import("@/legalcontracts/CreateContract.vue"),
        }],
})